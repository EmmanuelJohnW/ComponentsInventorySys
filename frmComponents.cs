using System.Data;

namespace ElectronicsInventory;

// ============================================================
// frmCars.cs  –  Component Management Form
// ============================================================
// This form lets staff manage electronic components in the inventory.
//
// OPERATIONS:
//   Add    – Registers a new component. Part No. must be unique.
//   Update – Edits the selected component's details.
//   Delete – Removes a component. Blocked if the component is
//            currently checked out (to avoid orphaned records).
//   Clear  – Resets all input fields and deselects the grid.
//
// FIELDS:
//   Part No.     – Manufacturer's part number (e.g. "ATM328P-AU")
//   Manufacturer – Company that made the component
//   Part Name    – Descriptive name (e.g. "ATmega328P Microcontroller")
//   Qty          – Number of units in stock
//   Unit Cost    – Cost per unit in currency
//   Status       – "In Stock", "Checked Out", or "Defective"
//
// HOW THE GRID WORKS:
//   The DataGridView (dgvComponents) is bound to DataStore.Components
//   which is an in-memory DataTable. Any change made through
//   DataStore (Add/Update/Delete) automatically refreshes the grid.
// ============================================================

public partial class frmComponents : Form
{
    // _selectedId tracks which component is currently selected in the grid.
    // -1 means nothing is selected (used to block Update/Delete).
    private int _selectedId = -1;

    // _suppressSelection prevents the SelectionChanged event from firing
    // while we are programmatically clearing the form, which would
    // otherwise trigger unwanted field population.
    private bool _suppressSelection;

    public frmComponents()
    {
        InitializeComponent(); // Auto-generated: sets up all UI controls.
    }

    // Runs when the form first opens.
    private void frmComponents_Load(object sender, EventArgs e)
    {
        // Default the status dropdown to the first item ("In Stock").
        cmbStatus.SelectedIndex = 0;

        // Bind the grid to the in-memory DataTable.
        // DefaultView supports live filtering (used by the search box).
        dgvComponents.DataSource = DataStore.Components.DefaultView;

        RenameHeaders(); // Make column headers more readable.
    }

    // Replaces the raw column names (from the DataTable) with
    // friendlier display names in the grid header row.
    private void RenameHeaders()
    {
        if (!dgvComponents.Columns.Contains("ComponentID")) return;
        dgvComponents.Columns["ComponentID"].HeaderText = "ID";
        dgvComponents.Columns["PartNo"].HeaderText      = "Part No.";
        dgvComponents.Columns["PartName"].HeaderText    = "Part Name";
        dgvComponents.Columns["UnitCost"].HeaderText    = "Unit Cost";
    }

    // Fires every time the user types in the search box.
    // Applies a row filter to the DataTable's DefaultView so only
    // matching rows show in the grid — no database query needed.
    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        // Escape single quotes to avoid breaking the filter expression.
        string f = txtSearch.Text.Trim().Replace("'", "''");

        // DataView.RowFilter uses SQL-like syntax (LIKE, AND, OR).
        // An empty filter string removes all filtering and shows all rows.
        DataStore.Components.DefaultView.RowFilter = string.IsNullOrEmpty(f) ? "" :
            $"PartNo LIKE '%{f}%' OR Manufacturer LIKE '%{f}%' OR PartName LIKE '%{f}%'";
    }

    // Fires when the user clicks a row in the grid.
    // Populates the input fields with the selected component's data
    // so the user can review or edit it.
    private void dgvComponents_SelectionChanged(object sender, EventArgs e)
    {
        // _suppressSelection is true while ClearForm() is running —
        // ignore the event to avoid refilling the fields we just cleared.
        if (_suppressSelection || dgvComponents.SelectedRows.Count == 0) return;

        var row = dgvComponents.SelectedRows[0];

        // Remember the ID so Update and Delete know which record to change.
        _selectedId          = Convert.ToInt32(row.Cells["ComponentID"].Value);
        txtPartNo.Text       = row.Cells["PartNo"].Value?.ToString();
        txtManufacturer.Text = row.Cells["Manufacturer"].Value?.ToString();
        txtPartName.Text     = row.Cells["PartName"].Value?.ToString();
        txtQty.Text          = row.Cells["Qty"].Value?.ToString();
        txtUnitCost.Text     = row.Cells["UnitCost"].Value?.ToString();

        // Sync the status dropdown to match the selected row's status.
        string status = row.Cells["Status"].Value?.ToString() ?? "In Stock";
        int idx = cmbStatus.FindStringExact(status);
        cmbStatus.SelectedIndex = idx >= 0 ? idx : 0;
    }

    // Reads and validates all input fields.
    // Uses "out" parameters to return the parsed values to the caller.
    // Returns true if all fields are valid; false (with a MessageBox) otherwise.
    private bool ValidateInput(out string partNo, out string manufacturer,
        out string partName, out int qty, out decimal unitCost)
    {
        partNo       = txtPartNo.Text.Trim();
        manufacturer = txtManufacturer.Text.Trim();
        partName     = txtPartName.Text.Trim();
        qty          = 0;
        unitCost     = 0;

        // Required text fields must not be empty.
        if (string.IsNullOrWhiteSpace(partNo) || string.IsNullOrWhiteSpace(manufacturer) ||
            string.IsNullOrWhiteSpace(partName))
        {
            MessageBox.Show("Part No., Manufacturer, and Part Name are required.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Qty must be a non-negative integer.
        if (!int.TryParse(txtQty.Text, out qty) || qty < 0)
        {
            MessageBox.Show("Enter a valid Qty (0 or more).",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Unit Cost must be a non-negative decimal number.
        if (!decimal.TryParse(txtUnitCost.Text, out unitCost) || unitCost < 0)
        {
            MessageBox.Show("Enter a valid Unit Cost.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    // Helper: returns the currently selected status from the dropdown.
    private string SelectedStatus => cmbStatus.SelectedItem?.ToString() ?? "In Stock";

    // ----------------------------------------------------------
    // Add Button
    // ----------------------------------------------------------
    private void btnAdd_Click(object sender, EventArgs e)
    {
        // Step 1: Validate the input fields.
        if (!ValidateInput(out var partNo, out var manufacturer, out var partName,
            out var qty, out var unitCost)) return;

        // Step 2: Check for duplicate Part No. in the in-memory table.
        // (The database also has a UNIQUE constraint as a safety net.)
        if (DataStore.Components.Select($"PartNo = '{partNo}'").Length > 0)
        {
            MessageBox.Show("A component with that Part No. already exists.",
                "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Step 3: Save to the Supabase database (and sync to in-memory table).
        try
        {
            DataStore.AddComponent(partNo, manufacturer, partName, qty, unitCost, SelectedStatus);
        }
        catch (Exception ex)
        {
            // Show the database error message (e.g. connection lost, constraint violation).
            MessageBox.Show($"Database error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ClearForm();
        MessageBox.Show("Component added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ----------------------------------------------------------
    // Update Button
    // ----------------------------------------------------------
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // Must have a selected row before updating.
        if (_selectedId < 0)
        {
            MessageBox.Show("Select a component to update.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInput(out var partNo, out var manufacturer, out var partName,
            out var qty, out var unitCost)) return;

        // Save the updated values to the database and in-memory table.
        try
        {
            DataStore.UpdateComponent(_selectedId, partNo, manufacturer, partName, qty, unitCost, SelectedStatus);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ClearForm();
        MessageBox.Show("Component updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ----------------------------------------------------------
    // Delete Button
    // ----------------------------------------------------------
    private void btnDelete_Click(object sender, EventArgs e)
    {
        // Must have a selected row before deleting.
        if (_selectedId < 0)
        {
            MessageBox.Show("Select a component to delete.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Block deletion if the component is currently checked out.
        // Deleting it would leave the checkout record pointing to nothing.
        int activeCheckouts = DataStore.Checkouts
            .Select($"ComponentID = {_selectedId} AND Status = 'Checked Out'").Length;

        if (activeCheckouts > 0)
        {
            MessageBox.Show("Cannot delete a component that is currently checked out.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Ask the user to confirm before permanently deleting.
        if (MessageBox.Show("Delete this component?", "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        // Delete from the database and in-memory table.
        try
        {
            DataStore.DeleteComponent(_selectedId);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ClearForm();
    }

    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    // Resets all input fields and deselects the grid row.
    private void ClearForm()
    {
        // Prevent the grid's SelectionChanged event from re-filling the
        // fields while we are in the middle of clearing them.
        _suppressSelection = true;

        _selectedId = -1; // No component selected anymore.
        txtPartNo.Clear();
        txtManufacturer.Clear();
        txtPartName.Clear();
        txtQty.Clear();
        txtUnitCost.Clear();
        cmbStatus.SelectedIndex = 0; // Reset dropdown to "In Stock".
        dgvComponents.ClearSelection();

        _suppressSelection = false;
    }
}
