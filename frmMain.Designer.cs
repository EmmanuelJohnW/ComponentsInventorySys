namespace ElectronicsInventory
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle  = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyle    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAltCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.mnuMain                      = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem        = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout                    = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit                      = new System.Windows.Forms.ToolStripMenuItem();
            this.masterFileToolStripMenuItem  = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComponents                = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjects                  = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCheckouts                 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAvailability              = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports                   = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader                    = new System.Windows.Forms.Panel();
            this.lblHeaderTitle               = new System.Windows.Forms.Label();
            this.pnlDashboard                 = new System.Windows.Forms.Panel();
            this.pnlTotalComponents           = new System.Windows.Forms.Panel();
            this.lblTotalComponentsTitle      = new System.Windows.Forms.Label();
            this.lblTotalComponentsValue      = new System.Windows.Forms.Label();
            this.pnlInStock                   = new System.Windows.Forms.Panel();
            this.lblInStockTitle              = new System.Windows.Forms.Label();
            this.lblInStockValue              = new System.Windows.Forms.Label();
            this.pnlTotalProjects             = new System.Windows.Forms.Panel();
            this.lblTotalProjectsTitle        = new System.Windows.Forms.Label();
            this.lblTotalProjectsValue        = new System.Windows.Forms.Label();
            this.pnlActiveCheckouts           = new System.Windows.Forms.Panel();
            this.lblActiveCheckoutsTitle      = new System.Windows.Forms.Label();
            this.lblActiveCheckoutsValue      = new System.Windows.Forms.Label();
            this.pnlGridHeader                = new System.Windows.Forms.Panel();
            this.lblGridTitle                 = new System.Windows.Forms.Label();
            this.dgvTodayCheckouts            = new System.Windows.Forms.DataGridView();

            this.mnuMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlTotalComponents.SuspendLayout();
            this.pnlInStock.SuspendLayout();
            this.pnlTotalProjects.SuspendLayout();
            this.pnlActiveCheckouts.SuspendLayout();
            this.pnlGridHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayCheckouts)).BeginInit();
            this.SuspendLayout();

            // ── mnuMain ─────────────────────────────────────────────────
            this.mnuMain.BackColor = System.Drawing.Color.FromArgb(42, 42, 42);
            this.mnuMain.Dock      = System.Windows.Forms.DockStyle.Top;
            this.mnuMain.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.mnuMain.ForeColor = System.Drawing.Color.White;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileToolStripMenuItem,
                this.masterFileToolStripMenuItem,
                this.transactionsToolStripMenuItem,
                this.mnuReports });
            this.mnuMain.Name       = "mnuMain";
            this.mnuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMain.Size       = new System.Drawing.Size(1008, 24);
            this.mnuMain.TabIndex   = 0;

            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuLogout, this.mnuExit });
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name      = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Text      = "File";

            this.mnuLogout.Name  = "mnuLogout";
            this.mnuLogout.Text  = "Logout";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);

            this.mnuExit.Name  = "mnuExit";
            this.mnuExit.Text  = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);

            this.masterFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuComponents, this.mnuProjects });
            this.masterFileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.masterFileToolStripMenuItem.Name      = "masterFileToolStripMenuItem";
            this.masterFileToolStripMenuItem.Text      = "Master File";

            this.mnuComponents.Name  = "mnuComponents";
            this.mnuComponents.Text  = "Components";
            this.mnuComponents.Click += new System.EventHandler(this.mnuComponents_Click);

            this.mnuProjects.Name  = "mnuProjects";
            this.mnuProjects.Text  = "Projects";
            this.mnuProjects.Click += new System.EventHandler(this.mnuProjects_Click);

            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuCheckouts, this.mnuAvailability });
            this.transactionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.transactionsToolStripMenuItem.Name      = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Text      = "Transactions";

            this.mnuCheckouts.Name  = "mnuCheckouts";
            this.mnuCheckouts.Text  = "Checkouts";
            this.mnuCheckouts.Click += new System.EventHandler(this.mnuCheckouts_Click);

            this.mnuAvailability.Name  = "mnuAvailability";
            this.mnuAvailability.Text  = "Stock Status";
            this.mnuAvailability.Click += new System.EventHandler(this.mnuAvailability_Click);

            this.mnuReports.ForeColor = System.Drawing.Color.White;
            this.mnuReports.Name      = "mnuReports";
            this.mnuReports.Text      = "Reports";
            this.mnuReports.Click    += new System.EventHandler(this.mnuReports_Click);

            // ── pnlHeader (title band) ───────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(136, 59, 47);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name      = "pnlHeader";
            this.pnlHeader.Size      = new System.Drawing.Size(1008, 52);
            this.pnlHeader.TabIndex  = 4;

            this.lblHeaderTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Name      = "lblHeaderTitle";
            this.lblHeaderTitle.Text      = "ELECTRONICS INVENTORY SYSTEM";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeaderTitle.Padding   = new System.Windows.Forms.Padding(18, 0, 0, 0);

            // ── pnlDashboard ─────────────────────────────────────────────
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(58, 58, 58);
            this.pnlDashboard.Controls.Add(this.pnlTotalComponents);
            this.pnlDashboard.Controls.Add(this.pnlInStock);
            this.pnlDashboard.Controls.Add(this.pnlTotalProjects);
            this.pnlDashboard.Controls.Add(this.pnlActiveCheckouts);
            this.pnlDashboard.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboard.Name      = "pnlDashboard";
            this.pnlDashboard.Padding   = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.pnlDashboard.Size      = new System.Drawing.Size(1008, 148);
            this.pnlDashboard.TabIndex  = 1;

            // Card 1 – Total Components
            this.pnlTotalComponents.BackColor = System.Drawing.Color.FromArgb(78, 68, 66);
            this.pnlTotalComponents.Controls.Add(this.lblTotalComponentsTitle);
            this.pnlTotalComponents.Controls.Add(this.lblTotalComponentsValue);
            this.pnlTotalComponents.Location = new System.Drawing.Point(18, 12);
            this.pnlTotalComponents.Name     = "pnlTotalComponents";
            this.pnlTotalComponents.Size     = new System.Drawing.Size(200, 112);
            this.pnlTotalComponents.TabIndex = 0;

            this.lblTotalComponentsTitle.AutoSize  = true;
            this.lblTotalComponentsTitle.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalComponentsTitle.ForeColor = System.Drawing.Color.FromArgb(136, 59, 47);
            this.lblTotalComponentsTitle.Location  = new System.Drawing.Point(12, 12);
            this.lblTotalComponentsTitle.Name      = "lblTotalComponentsTitle";
            this.lblTotalComponentsTitle.Text      = "TOTAL COMPONENTS";

            this.lblTotalComponentsValue.AutoSize  = true;
            this.lblTotalComponentsValue.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalComponentsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalComponentsValue.Location  = new System.Drawing.Point(10, 32);
            this.lblTotalComponentsValue.Name      = "lblTotalComponentsValue";
            this.lblTotalComponentsValue.Text      = "0";

            // Card 2 – In Stock
            this.pnlInStock.BackColor = System.Drawing.Color.FromArgb(66, 78, 68);
            this.pnlInStock.Controls.Add(this.lblInStockTitle);
            this.pnlInStock.Controls.Add(this.lblInStockValue);
            this.pnlInStock.Location = new System.Drawing.Point(238, 12);
            this.pnlInStock.Name     = "pnlInStock";
            this.pnlInStock.Size     = new System.Drawing.Size(200, 112);
            this.pnlInStock.TabIndex = 1;

            this.lblInStockTitle.AutoSize  = true;
            this.lblInStockTitle.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblInStockTitle.ForeColor = System.Drawing.Color.FromArgb(70, 160, 80);
            this.lblInStockTitle.Location  = new System.Drawing.Point(12, 12);
            this.lblInStockTitle.Name      = "lblInStockTitle";
            this.lblInStockTitle.Text      = "IN STOCK";

            this.lblInStockValue.AutoSize  = true;
            this.lblInStockValue.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblInStockValue.ForeColor = System.Drawing.Color.White;
            this.lblInStockValue.Location  = new System.Drawing.Point(10, 32);
            this.lblInStockValue.Name      = "lblInStockValue";
            this.lblInStockValue.Text      = "0";

            // Card 3 – Total Projects
            this.pnlTotalProjects.BackColor = System.Drawing.Color.FromArgb(78, 75, 62);
            this.pnlTotalProjects.Controls.Add(this.lblTotalProjectsTitle);
            this.pnlTotalProjects.Controls.Add(this.lblTotalProjectsValue);
            this.pnlTotalProjects.Location = new System.Drawing.Point(458, 12);
            this.pnlTotalProjects.Name     = "pnlTotalProjects";
            this.pnlTotalProjects.Size     = new System.Drawing.Size(200, 112);
            this.pnlTotalProjects.TabIndex = 2;

            this.lblTotalProjectsTitle.AutoSize  = true;
            this.lblTotalProjectsTitle.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalProjectsTitle.ForeColor = System.Drawing.Color.FromArgb(200, 150, 50);
            this.lblTotalProjectsTitle.Location  = new System.Drawing.Point(12, 12);
            this.lblTotalProjectsTitle.Name      = "lblTotalProjectsTitle";
            this.lblTotalProjectsTitle.Text      = "TOTAL PROJECTS";

            this.lblTotalProjectsValue.AutoSize  = true;
            this.lblTotalProjectsValue.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalProjectsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalProjectsValue.Location  = new System.Drawing.Point(10, 32);
            this.lblTotalProjectsValue.Name      = "lblTotalProjectsValue";
            this.lblTotalProjectsValue.Text      = "0";

            // Card 4 – Active Checkouts
            this.pnlActiveCheckouts.BackColor = System.Drawing.Color.FromArgb(78, 64, 64);
            this.pnlActiveCheckouts.Controls.Add(this.lblActiveCheckoutsTitle);
            this.pnlActiveCheckouts.Controls.Add(this.lblActiveCheckoutsValue);
            this.pnlActiveCheckouts.Location = new System.Drawing.Point(678, 12);
            this.pnlActiveCheckouts.Name     = "pnlActiveCheckouts";
            this.pnlActiveCheckouts.Size     = new System.Drawing.Size(200, 112);
            this.pnlActiveCheckouts.TabIndex = 3;

            this.lblActiveCheckoutsTitle.AutoSize  = true;
            this.lblActiveCheckoutsTitle.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblActiveCheckoutsTitle.ForeColor = System.Drawing.Color.FromArgb(200, 80, 80);
            this.lblActiveCheckoutsTitle.Location  = new System.Drawing.Point(12, 12);
            this.lblActiveCheckoutsTitle.Name      = "lblActiveCheckoutsTitle";
            this.lblActiveCheckoutsTitle.Text      = "ACTIVE CHECKOUTS";

            this.lblActiveCheckoutsValue.AutoSize  = true;
            this.lblActiveCheckoutsValue.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblActiveCheckoutsValue.ForeColor = System.Drawing.Color.White;
            this.lblActiveCheckoutsValue.Location  = new System.Drawing.Point(10, 32);
            this.lblActiveCheckoutsValue.Name      = "lblActiveCheckoutsValue";
            this.lblActiveCheckoutsValue.Text      = "0";

            // ── pnlGridHeader ────────────────────────────────────────────
            this.pnlGridHeader.BackColor = System.Drawing.Color.FromArgb(136, 59, 47);
            this.pnlGridHeader.Controls.Add(this.lblGridTitle);
            this.pnlGridHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlGridHeader.Name     = "pnlGridHeader";
            this.pnlGridHeader.Size     = new System.Drawing.Size(1008, 36);
            this.pnlGridHeader.TabIndex = 5;

            this.lblGridTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblGridTitle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.White;
            this.lblGridTitle.Name      = "lblGridTitle";
            this.lblGridTitle.Text      = "Today's Active Checkouts";
            this.lblGridTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGridTitle.Padding   = new System.Windows.Forms.Padding(16, 0, 0, 0);

            // ── dgvTodayCheckouts ────────────────────────────────────────
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 40, 30);
            dgvHeaderStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;

            dgvCellStyle.BackColor          = System.Drawing.Color.FromArgb(62, 62, 62);
            dgvCellStyle.ForeColor          = System.Drawing.Color.White;
            dgvCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(136, 59, 47);
            dgvCellStyle.SelectionForeColor = System.Drawing.Color.White;

            dgvAltCellStyle.BackColor          = System.Drawing.Color.FromArgb(70, 70, 70);
            dgvAltCellStyle.ForeColor          = System.Drawing.Color.White;
            dgvAltCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(136, 59, 47);
            dgvAltCellStyle.SelectionForeColor = System.Drawing.Color.White;

            this.dgvTodayCheckouts.AllowUserToAddRows             = false;
            this.dgvTodayCheckouts.AllowUserToDeleteRows          = false;
            this.dgvTodayCheckouts.AlternatingRowsDefaultCellStyle = dgvAltCellStyle;
            this.dgvTodayCheckouts.AutoSizeColumnsMode            = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodayCheckouts.BackgroundColor                = System.Drawing.Color.FromArgb(58, 58, 58);
            this.dgvTodayCheckouts.BorderStyle                    = System.Windows.Forms.BorderStyle.None;
            this.dgvTodayCheckouts.CellBorderStyle                = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTodayCheckouts.ColumnHeadersDefaultCellStyle  = dgvHeaderStyle;
            this.dgvTodayCheckouts.ColumnHeadersHeightSizeMode    = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayCheckouts.DefaultCellStyle               = dgvCellStyle;
            this.dgvTodayCheckouts.Dock                           = System.Windows.Forms.DockStyle.Fill;
            this.dgvTodayCheckouts.EnableHeadersVisualStyles      = false;
            this.dgvTodayCheckouts.GridColor                      = System.Drawing.Color.FromArgb(88, 88, 88);
            this.dgvTodayCheckouts.Name                           = "dgvTodayCheckouts";
            this.dgvTodayCheckouts.ReadOnly                       = true;
            this.dgvTodayCheckouts.RowHeadersVisible              = false;
            this.dgvTodayCheckouts.RowTemplate.Height             = 32;
            this.dgvTodayCheckouts.SelectionMode                  = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTodayCheckouts.TabIndex                       = 2;

            // ── frmMain ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(60, 60, 60);
            this.ClientSize          = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.dgvTodayCheckouts);
            this.Controls.Add(this.pnlGridHeader);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name          = "frmMain";
            this.Text          = "Electronics Inventory System";
            this.WindowState   = System.Windows.Forms.FormWindowState.Maximized;
            this.Load         += new System.EventHandler(this.frmMain_Load);

            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlTotalComponents.ResumeLayout(false);
            this.pnlTotalComponents.PerformLayout();
            this.pnlInStock.ResumeLayout(false);
            this.pnlInStock.PerformLayout();
            this.pnlTotalProjects.ResumeLayout(false);
            this.pnlTotalProjects.PerformLayout();
            this.pnlActiveCheckouts.ResumeLayout(false);
            this.pnlActiveCheckouts.PerformLayout();
            this.pnlGridHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayCheckouts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip         mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem masterFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuComponents;
        private System.Windows.Forms.ToolStripMenuItem mnuProjects;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckouts;
        private System.Windows.Forms.ToolStripMenuItem mnuAvailability;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblHeaderTitle;
        private System.Windows.Forms.Panel   pnlDashboard;
        private System.Windows.Forms.Panel   pnlTotalComponents;
        private System.Windows.Forms.Label   lblTotalComponentsTitle;
        private System.Windows.Forms.Label   lblTotalComponentsValue;
        private System.Windows.Forms.Panel   pnlInStock;
        private System.Windows.Forms.Label   lblInStockTitle;
        private System.Windows.Forms.Label   lblInStockValue;
        private System.Windows.Forms.Panel   pnlTotalProjects;
        private System.Windows.Forms.Label   lblTotalProjectsTitle;
        private System.Windows.Forms.Label   lblTotalProjectsValue;
        private System.Windows.Forms.Panel   pnlActiveCheckouts;
        private System.Windows.Forms.Label   lblActiveCheckoutsTitle;
        private System.Windows.Forms.Label   lblActiveCheckoutsValue;
        private System.Windows.Forms.Panel   pnlGridHeader;
        private System.Windows.Forms.Label   lblGridTitle;
        private System.Windows.Forms.DataGridView dgvTodayCheckouts;
    }
}
