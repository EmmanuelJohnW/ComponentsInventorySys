namespace ElectronicsInventory;

// ============================================================
// frmMain.cs  –  Main Dashboard
// ============================================================
// The central hub of the application. Opens after a successful
// login and stays open for the entire session.
//
// DASHBOARD STAT CARDS (top row):
//   Total Components  – Total number of component records
//   In Stock          – Components with Status = "In Stock"
//   Total Projects    – Total number of registered projects
//   Active Checkouts  – Checkouts with Status = "Checked Out"
//   These counters are read from the in-memory DataTables
//   (DataStore.Components, DataStore.Projects, DataStore.Checkouts)
//   and refresh every time you return from a child form.
//
// TODAY'S CHECKOUTS GRID:
//   Shows checkouts that are active today — where the checkout
//   date range overlaps today's date. Calls GetCheckoutsView
//   with from=today and to=today.
//
// MENU BAR:
//   Each menu item opens the corresponding form as a modal
//   dialog (ShowDialog). When the dialog closes, RefreshDashboard
//   is called so the stat cards reflect any changes made.
//
// LOGOUT:
//   Hides the dashboard and shows the login window again.
//   If the user closes the login window without logging in,
//   the application exits completely.
// ============================================================

public partial class frmMain : Form
{
    public frmMain()
    {
        InitializeComponent(); // Auto-generated: sets up all UI controls.
    }

    // Runs when the dashboard first opens.
    private void frmMain_Load(object sender, EventArgs e)
    {
        RefreshDashboard();    // Populate the stat cards.
        LoadTodayCheckouts();  // Populate the today's checkouts grid.
    }

    // Updates the four stat cards at the top of the window.
    // Reads counts directly from the in-memory DataTables —
    // no database query needed because the tables are already loaded.
    private void RefreshDashboard()
    {
        // Total number of component rows in the in-memory table.
        lblTotalComponentsValue.Text =
            DataStore.Components.Rows.Count.ToString();

        // Count only rows where Status equals "In Stock".
        // DataTable.Select() works like a SQL WHERE clause.
        lblInStockValue.Text =
            DataStore.Components.Select("Status = 'In Stock'").Length.ToString();

        // Total number of project rows.
        lblTotalProjectsValue.Text =
            DataStore.Projects.Rows.Count.ToString();

        // Count only checkouts that are still active (not returned).
        lblActiveCheckoutsValue.Text =
            DataStore.Checkouts.Select("Status = 'Checked Out'").Length.ToString();
    }

    // Fills the grid with checkouts that are active today.
    // "Active today" means the checkout period includes today's date:
    //   CheckoutDate <= today AND ReturnDate >= today
    private void LoadTodayCheckouts()
    {
        // activeOnly: true so returned components disappear from this grid immediately.
        dgvTodayCheckouts.DataSource =
            DataStore.GetCheckoutsView(from: DateTime.Today, to: DateTime.Today, activeOnly: true);
    }

    // ----------------------------------------------------------
    // Menu Item Handlers
    // ----------------------------------------------------------

    // Logout: hide the dashboard, show the login window.
    // If the user cancels/closes the login window, exit the app.
    private void mnuLogout_Click(object sender, EventArgs e)
    {
        Hide(); // Hide dashboard (don't close — we reuse it if login succeeds).

        using var login = new frmLogin();
        if (login.ShowDialog() != DialogResult.OK)
        {
            Application.Exit(); // User closed the login window — exit.
            return;
        }

        // Login succeeded — show the dashboard again with fresh data.
        Show();
        RefreshDashboard();
        LoadTodayCheckouts();
    }

    private void mnuExit_Click(object sender, EventArgs e) => Application.Exit();

    // Open the Component Management form as a modal dialog.
    // After it closes, refresh the dashboard stat cards.
    private void mnuComponents_Click(object sender, EventArgs e)
    {
        new frmComponents().ShowDialog(this);
        RefreshDashboard();   // Stat cards may have changed.
        LoadTodayCheckouts(); // Grid must refresh — a component may have been returned.
    }

    // Open the Project Management form.
    private void mnuProjects_Click(object sender, EventArgs e)
    {
        new frmProjects().ShowDialog(this);
        RefreshDashboard(); // Stats may have changed (projects added/deleted).
    }

    // Open the Component Checkout form.
    private void mnuCheckouts_Click(object sender, EventArgs e)
    {
        new frmCheckouts().ShowDialog(this);
        RefreshDashboard();    // Active checkouts count may have changed.
        LoadTodayCheckouts();  // Today's grid may have new entries.
    }

    // Open the Stock Status / Availability checker (read-only — no refresh needed).
    private void mnuAvailability_Click(object sender, EventArgs e)
        => new frmStockStatus().ShowDialog(this);

    // Open the Reports form (read-only — no refresh needed).
    private void mnuReports_Click(object sender, EventArgs e)
        => new frmReports().ShowDialog(this);
}
