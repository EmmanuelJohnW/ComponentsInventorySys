using System.Data;

namespace ElectronicsInventory;

// ============================================================
// frmAvailability.cs  –  Stock Status / Component Availability
// ============================================================
// A read-only form that answers the question:
//   "Which components are available between Date A and Date B?"
//
// HOW IT WORKS:
//   1. The user picks a start date and end date, then clicks Check.
//   2. The code finds all components currently checked out whose
//      checkout period OVERLAPS the requested date range.
//      Two date ranges overlap if:
//        checkout.CheckoutDate <= requested.EndDate
//        AND checkout.ReturnDate >= requested.StartDate
//   3. Any "In Stock" component that is NOT in that "busy" list
//      is shown in the results grid as available.
//
// This form is READ-ONLY — it does not add, change, or delete data.
// It reads from the in-memory DataTables (no database queries here).
//
// EXAMPLE:
//   Requested range: June 1 – June 7
//   Component X is checked out: May 30 – June 3  → BUSY (overlaps)
//   Component Y is checked out: June 8 – June 10 → FREE (no overlap)
//   Component Z has Status = "In Stock", no checkout → FREE
// ============================================================

public partial class frmStockStatus : Form
{
    public frmStockStatus()
    {
        InitializeComponent(); // Auto-generated: sets up all UI controls.
    }

    // Fires when the user clicks the Check Availability button.
    private void btnCheck_Click(object sender, EventArgs e)
    {
        // Validate: end date must be strictly after start date.
        if (dtpEnd.Value.Date <= dtpStart.Value.Date)
        {
            MessageBox.Show("End date must be after start date.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DateTime start = dtpStart.Value.Date;
        DateTime end   = dtpEnd.Value.Date;

        // Step 1: Collect the IDs of components that are "busy" during
        // the requested period — i.e., checked out and overlapping our range.
        // A HashSet is used for fast O(1) lookups in Step 2.
        var busyComponentIds = DataStore.Checkouts.AsEnumerable()
            .Where(r =>
                (string)r["Status"] == "Checked Out" &&
                (DateTime)r["CheckoutDate"] <= end   && // checkout started before our end
                (DateTime)r["ReturnDate"]   >= start)   // checkout ends after our start
            .Select(r => (int)r["ComponentID"])
            .ToHashSet();

        // Step 2: Build the results table.
        // Include only "In Stock" components that are NOT in the busy list.
        var result = new DataTable();
        result.Columns.Add("ID",           typeof(int));
        result.Columns.Add("Part No.",     typeof(string));
        result.Columns.Add("Manufacturer", typeof(string));
        result.Columns.Add("Part Name",    typeof(string));
        result.Columns.Add("Qty",          typeof(int));
        result.Columns.Add("Unit Cost",    typeof(decimal));

        foreach (DataRow r in DataStore.Components.Select("Status = 'In Stock'"))
        {
            // Skip this component if it's busy during the requested period.
            if (!busyComponentIds.Contains((int)r["ComponentID"]))
                result.Rows.Add(
                    (int)r["ComponentID"],
                    (string)r["PartNo"],
                    (string)r["Manufacturer"],
                    (string)r["PartName"],
                    (int)r["Qty"],
                    (decimal)r["UnitCost"]);
        }

        // Display the results and update the title with the count.
        dgvAvailable.DataSource = result;
        lblTitle.Text = $"Check Component Availability  —  {result.Rows.Count} component(s) available";
    }
}
