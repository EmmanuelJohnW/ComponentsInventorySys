using System.Data;

namespace ElectronicsInventory;

// ============================================================
// frmRentals.cs  –  Component Checkout Form
// ============================================================
// This form is where staff record a component being borrowed
// by a project.
//
// WORKFLOW:
//   1. Select an available ("In Stock") component from the dropdown.
//      The component's unit cost is auto-filled into the Value field.
//   2. Select the project that is borrowing the component.
//   3. Set the checkout date (defaults to today) and the expected
//      return date (defaults to 7 days from today).
//   4. Click Save — this:
//        a. Creates a checkout record in the database.
//        b. Marks the component's status as "Checked Out" so it
//           no longer appears in the available list.
//      Both changes happen in a single database transaction,
//      meaning they always succeed or fail together.
//
// BOTTOM GRID:
//   Shows all existing checkout records with human-readable
//   component and project names (not raw IDs).
// ============================================================

public partial class frmCheckouts : Form
{
    // Stores the unit cost of the currently selected component.
    // Set when the user picks a component from the dropdown.
    private decimal _unitCost;

    // Prevents the component dropdown's SelectedIndexChanged event
    // from firing while we are programmatically populating it.
    private bool _loadingComponents;

    public frmCheckouts()
    {
        InitializeComponent(); // Auto-generated: sets up all UI controls.
    }

    // Runs when the form opens.
    private void frmCheckouts_Load(object sender, EventArgs e)
    {
        // Set sensible default dates: check out today, return in one week.
        dtpCheckoutDate.Value = DateTime.Today;
        dtpReturnDate.Value   = DateTime.Today.AddDays(7);

        LoadAvailableComponents(); // Fill the component dropdown.
        LoadProjects();            // Fill the project dropdown.
        LoadCheckouts();           // Fill the bottom grid.
    }

    // Populates the component dropdown with only "In Stock" components.
    // Components that are already "Checked Out" or "Defective" are excluded
    // because they can't be checked out again until returned.
    private void LoadAvailableComponents()
    {
        _loadingComponents = true; // Pause the SelectedIndexChanged event.

        // Build a small DataTable to use as the dropdown's data source.
        // Using a DataTable lets us bind a display string and a hidden ID.
        var dt = new DataTable();
        dt.Columns.Add("ComponentID", typeof(int));
        dt.Columns.Add("Display",     typeof(string));

        // Only include components that are currently in stock.
        foreach (DataRow r in DataStore.Components.Select("Status = 'In Stock'"))
            dt.Rows.Add(
                (int)r["ComponentID"],
                // Format: "PartNo – Manufacturer PartName" for easy identification.
                $"{r["PartNo"]} – {r["Manufacturer"]} {r["PartName"]}");

        cmbComponent.DataSource    = dt;
        cmbComponent.DisplayMember = "Display";      // Text shown in dropdown.
        cmbComponent.ValueMember   = "ComponentID";  // Hidden value used in code.

        _loadingComponents = false; // Resume the SelectedIndexChanged event.
        ShowUnitValue();            // Update the unit cost field for the first item.
    }

    // Populates the project dropdown with all registered projects.
    private void LoadProjects()
    {
        var dt = new DataTable();
        dt.Columns.Add("ProjectID",   typeof(int));
        dt.Columns.Add("ProjectName", typeof(string));

        foreach (DataRow r in DataStore.Projects.Rows)
            dt.Rows.Add((int)r["ProjectID"], (string)r["ProjectName"]);

        cmbProject.DataSource    = dt;
        cmbProject.DisplayMember = "ProjectName";
        cmbProject.ValueMember   = "ProjectID";
    }

    // Refreshes the bottom grid with all checkout records.
    // GetCheckoutsView() returns a joined view showing names instead of IDs.
    private void LoadCheckouts()
    {
        dgvCheckouts.DataSource = DataStore.GetCheckoutsView();
    }

    // Fires whenever the user picks a different component from the dropdown.
    // Looks up the component's unit cost and displays it in the read-only field.
    private void cmbComponent_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Ignore this event while we are filling the dropdown programmatically.
        if (_loadingComponents || cmbComponent.SelectedValue == null) return;

        int compId = Convert.ToInt32(cmbComponent.SelectedValue);

        // Look up the unit cost from the in-memory Components table.
        var rows  = DataStore.Components.Select($"ComponentID = {compId}");
        _unitCost = rows.Length > 0 ? (decimal)rows[0]["UnitCost"] : 0;

        ShowUnitValue();
    }

    // Updates the read-only Unit Value field to show the selected component's cost.
    private void ShowUnitValue()
    {
        txtUnitValue.Text = _unitCost.ToString("N2"); // Format as "1,234.56"
    }

    // ----------------------------------------------------------
    // Save Checkout Button
    // ----------------------------------------------------------
    private void btnSaveCheckout_Click(object sender, EventArgs e)
    {
        // Guard: no components in stock.
        if (cmbComponent.SelectedValue == null)
        {
            MessageBox.Show("No available components in stock.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Guard: no projects registered.
        if (cmbProject.SelectedValue == null)
        {
            MessageBox.Show("No projects registered yet.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Guard: return date must be strictly after checkout date.
        if (dtpReturnDate.Value.Date <= dtpCheckoutDate.Value.Date)
        {
            MessageBox.Show("Return date must be after checkout date.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int compId = Convert.ToInt32(cmbComponent.SelectedValue);
        int projId = Convert.ToInt32(cmbProject.SelectedValue);

        // Save the checkout to the database.
        // AddCheckout() also updates the component's status to "Checked Out"
        // in the same database transaction (both changes are atomic).
        try
        {
            DataStore.AddCheckout(
                compId, projId,
                dtpCheckoutDate.Value.Date,
                dtpReturnDate.Value.Date,
                _unitCost,
                "Checked Out");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        MessageBox.Show("Checkout saved successfully.",
            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Refresh both dropdowns and the grid to reflect the new state.
        // The checked-out component will disappear from the available list.
        LoadAvailableComponents();
        LoadCheckouts();
    }
}
