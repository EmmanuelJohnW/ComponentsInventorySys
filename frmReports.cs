using System.Data;
using System.Text;

namespace ElectronicsInventory;

// ============================================================
// frmReports.cs  –  Reports & CSV Export
// ============================================================
// A read-only form for generating and exporting reports about
// component checkouts within a selected date range.
//
// REPORT TYPES:
//
//   "All Checkouts" (index 0)
//     A flat list of every checkout transaction within the date
//     range. Shows component name, project name, dates, value,
//     and status. Calls DataStore.GetCheckoutsView(from, to).
//
//   "Value Summary" (index 1)
//     Groups checkouts by date and shows:
//       - How many checkouts happened each day
//       - The total unit value checked out each day
//     Calls DataStore.GetValueSummary(from, to).
//
// CSV EXPORT:
//   The Export button saves the currently displayed report to a
//   .csv file chosen by the user. CSV (Comma-Separated Values)
//   can be opened in Excel or Google Sheets for further analysis.
//
// This form is READ-ONLY — it does not modify any data.
// ============================================================

public partial class frmReports : Form
{
    public frmReports()
    {
        InitializeComponent(); // Auto-generated: sets up all UI controls.
    }

    // Runs when the form opens.
    private void frmReports_Load(object sender, EventArgs e)
    {
        // Default to the first report type ("All Checkouts").
        cmbReportType.SelectedIndex = 0;

        // Default date range: first day of the current month to today.
        dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        dtpTo.Value   = DateTime.Today;
    }

    // Fires when the user clicks Generate Report.
    private void btnGenerate_Click(object sender, EventArgs e)
    {
        DateTime from = dtpFrom.Value.Date;
        DateTime to   = dtpTo.Value.Date;

        // Validate: "To" date cannot be before "From" date.
        if (to < from)
        {
            MessageBox.Show("'To' date cannot be before 'From' date.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Call the appropriate DataStore method based on which report is selected.
        // The result is a DataTable that gets bound directly to the grid.
        dgvReport.DataSource = cmbReportType.SelectedIndex == 1
            ? DataStore.GetValueSummary(from, to)    // "Value Summary" report
            : DataStore.GetCheckoutsView(from, to);  // "All Checkouts" report
    }

    // Fires when the user clicks Export to CSV.
    private void btnExportCSV_Click(object sender, EventArgs e)
    {
        // Cannot export if no report has been generated yet.
        if (dgvReport.DataSource == null || dgvReport.Rows.Count == 0)
        {
            MessageBox.Show("Generate a report first.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Open a Save File dialog so the user can choose where to save the CSV.
        using var dlg = new SaveFileDialog
        {
            Filter   = "CSV files (*.csv)|*.csv",
            FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv" // Auto-suggest a filename.
        };

        if (dlg.ShowDialog() != DialogResult.OK) return; // User cancelled.

        try
        {
            var sb = new StringBuilder();

            // Write the header row: one column name per cell, each quoted.
            // Quoting prevents issues if a column name contains a comma.
            var headers = dgvReport.Columns
                .Cast<DataGridViewColumn>()
                .Select(c => $"\"{c.HeaderText}\"");
            sb.AppendLine(string.Join(",", headers));

            // Write one data row per grid row.
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                if (row.IsNewRow) continue; // Skip the blank "new row" at the bottom.

                var cells = row.Cells
                    .Cast<DataGridViewCell>()
                    .Select(c => $"\"{c.Value}\""); // Quote each value to handle commas.
                sb.AppendLine(string.Join(",", cells));
            }

            // Write the CSV string to the chosen file using UTF-8 encoding.
            // UTF-8 ensures special characters (accents, symbols) are preserved.
            File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);

            MessageBox.Show("Report exported successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            // Show the error if the file could not be written
            // (e.g. file is open in Excel, no write permission).
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
