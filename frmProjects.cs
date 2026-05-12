using System.Data;

namespace ElectronicsInventory;

// ============================================================
// frmCustomers.cs  –  Project Management Form
// ============================================================
// This form manages the projects (groups/teams) that are allowed
// to borrow components from the inventory.
//
// OPERATIONS:
//   Add    – Registers a new project. Project Code must be unique.
//   Update – Edits the selected project's details.
//   Delete – Removes a project. Blocked if it has active checkouts
//            (to avoid orphaned checkout records).
//   Clear  – Resets all input fields and deselects the grid.
//
// FIELDS:
//   Project Name  – Full name of the project (e.g. "Line Following Robot")
//   Project Code  – Short unique identifier (e.g. "PRJ-2024-001")
//   Lead Name     – Name of the person responsible for the project
//   Email         – Contact email for the project lead (optional)
//
// HOW THE GRID WORKS:
//   The DataGridView (dgvProjects) is bound to DataStore.Projects,
//   an in-memory DataTable. Changes via DataStore methods automatically
//   update the grid without any manual refresh calls.
// ============================================================

public partial class frmProjects : Form
{
    // _selectedId tracks which project row is selected (-1 = none).
    private int  _selectedId = -1;

    // _suppressSelection stops the SelectionChanged handler from firing
    // while the form is being programmatically cleared.
    private bool _suppressSelection;

    public frmProjects()
    {
        InitializeComponent(); // Auto-generated: sets up all UI controls.
    }

    // Runs when the form first opens.
    private void frmProjects_Load(object sender, EventArgs e)
    {
        // Bind the grid to the in-memory Projects DataTable.
        // DefaultView supports live filtering (used by the search box).
        dgvProjects.DataSource = DataStore.Projects.DefaultView;
        RenameHeaders();
    }

    // Replaces raw DataTable column names with friendlier display names.
    private void RenameHeaders()
    {
        if (!dgvProjects.Columns.Contains("ProjectID")) return;
        dgvProjects.Columns["ProjectID"].HeaderText   = "ID";
        dgvProjects.Columns["ProjectName"].HeaderText = "Project Name";
        dgvProjects.Columns["ProjectCode"].HeaderText = "Project Code";
        dgvProjects.Columns["LeadName"].HeaderText    = "Lead Name";
    }

    // Fires every time the user types in the search box.
    // Filters the grid in real time without a database query.
    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        // Escape single quotes to prevent breaking the filter expression.
        string f = txtSearch.Text.Trim().Replace("'", "''");
        DataStore.Projects.DefaultView.RowFilter = string.IsNullOrEmpty(f) ? "" :
            $"ProjectName LIKE '%{f}%' OR ProjectCode LIKE '%{f}%' OR LeadName LIKE '%{f}%'";
    }

    // Fires when the user clicks a row in the grid.
    // Fills the input fields with the selected project's data.
    private void dgvProjects_SelectionChanged(object sender, EventArgs e)
    {
        if (_suppressSelection || dgvProjects.SelectedRows.Count == 0) return;

        var row = dgvProjects.SelectedRows[0];

        // Store the selected ID so Update/Delete know which record to act on.
        _selectedId         = Convert.ToInt32(row.Cells["ProjectID"].Value);
        txtProjectName.Text = row.Cells["ProjectName"].Value?.ToString();
        txtProjectCode.Text = row.Cells["ProjectCode"].Value?.ToString();
        txtLeadName.Text    = row.Cells["LeadName"].Value?.ToString();
        txtEmail.Text       = row.Cells["Email"].Value?.ToString();
    }

    // Reads and validates the input fields.
    // Returns true if valid; false (with a MessageBox) if not.
    private bool ValidateInput(out string projectName, out string projectCode,
        out string leadName, out string email)
    {
        projectName = txtProjectName.Text.Trim();
        projectCode = txtProjectCode.Text.Trim();
        leadName    = txtLeadName.Text.Trim();
        email       = txtEmail.Text.Trim();

        // Project Name and Project Code are required; Lead Name and Email are optional.
        if (string.IsNullOrWhiteSpace(projectName) || string.IsNullOrWhiteSpace(projectCode))
        {
            MessageBox.Show("Project Name and Project Code are required.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // ----------------------------------------------------------
    // Add Button
    // ----------------------------------------------------------
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateInput(out var projectName, out var projectCode,
            out var leadName, out var email)) return;

        // Check for a duplicate Project Code in the in-memory table.
        // The database also has a UNIQUE constraint as a backup.
        if (DataStore.Projects.Select($"ProjectCode = '{projectCode}'").Length > 0)
        {
            MessageBox.Show("A project with that Project Code already exists.",
                "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Save to the Supabase database and sync the in-memory table.
        try
        {
            DataStore.AddProject(projectName, projectCode, leadName, email);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ClearForm();
        MessageBox.Show("Project added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ----------------------------------------------------------
    // Update Button
    // ----------------------------------------------------------
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_selectedId < 0)
        {
            MessageBox.Show("Select a project to update.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInput(out var projectName, out var projectCode,
            out var leadName, out var email)) return;

        // Save the changes to the database and in-memory table.
        try
        {
            DataStore.UpdateProject(_selectedId, projectName, projectCode, leadName, email);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ClearForm();
        MessageBox.Show("Project updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ----------------------------------------------------------
    // Delete Button
    // ----------------------------------------------------------
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedId < 0)
        {
            MessageBox.Show("Select a project to delete.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Block deletion if the project currently has components checked out.
        // Deleting it would leave those checkout records with no project reference.
        int activeCheckouts = DataStore.Checkouts
            .Select($"ProjectID = {_selectedId} AND Status = 'Checked Out'").Length;

        if (activeCheckouts > 0)
        {
            MessageBox.Show("Cannot delete a project with active checkouts.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Confirm before permanently deleting.
        if (MessageBox.Show("Delete this project?", "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        // Delete from the database and in-memory table.
        try
        {
            DataStore.DeleteProject(_selectedId);
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
        _suppressSelection = true; // Pause the SelectionChanged event handler.

        _selectedId = -1;
        txtProjectName.Clear();
        txtProjectCode.Clear();
        txtLeadName.Clear();
        txtEmail.Clear();
        dgvProjects.ClearSelection();

        _suppressSelection = false;
    }
}
