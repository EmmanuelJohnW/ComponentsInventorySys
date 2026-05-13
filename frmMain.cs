namespace ElectronicsInventory;

public partial class frmMain : Form
{
    public frmMain()
    {
        InitializeComponent();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
        RefreshDashboard();
        LoadTodayCheckouts();
    }

    private void RefreshDashboard()
    {
        lblTotalComponentsValue.Text =
            DataStore.Components.Rows.Count.ToString();

        lblInStockValue.Text =
            DataStore.Components.Select("Status = 'In Stock'").Length.ToString();

        lblTotalProjectsValue.Text =
            DataStore.Projects.Rows.Count.ToString();

        lblActiveCheckoutsValue.Text =
            DataStore.Checkouts.Select("Status = 'Checked Out'").Length.ToString();
    }

    private void LoadTodayCheckouts()
    {
        dgvTodayCheckouts.DataSource =
            DataStore.GetCheckoutsView(from: DateTime.Today, to: DateTime.Today, activeOnly: true);
    }

    // ----------------------------------------------------------
    // Sidebar button handlers
    // ----------------------------------------------------------

    private void btnComponents_Click(object sender, EventArgs e)
    {
        new frmComponents().ShowDialog(this);
        RefreshDashboard();
        LoadTodayCheckouts();
    }

    private void btnProjects_Click(object sender, EventArgs e)
    {
        new frmProjects().ShowDialog(this);
        RefreshDashboard();
    }

    private void btnCheckouts_Click(object sender, EventArgs e)
    {
        new frmCheckouts().ShowDialog(this);
        RefreshDashboard();
        LoadTodayCheckouts();
    }

    private void btnStockStatus_Click(object sender, EventArgs e)
        => new frmStockStatus().ShowDialog(this);

    private void btnReports_Click(object sender, EventArgs e)
        => new frmReports().ShowDialog(this);

    private void btnLogout_Click(object sender, EventArgs e)
    {
        Hide();

        using var login = new frmLogin();
        if (login.ShowDialog() != DialogResult.OK)
        {
            Application.Exit();
            return;
        }

        Show();
        RefreshDashboard();
        LoadTodayCheckouts();
    }

    private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
}
