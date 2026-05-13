namespace ElectronicsInventory
{
    partial class frmReports
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

            this.pnlHeader     = new System.Windows.Forms.Panel();
            this.lblTitle      = new System.Windows.Forms.Label();
            this.pnlFilters    = new System.Windows.Forms.Panel();
            this.lblFrom       = new System.Windows.Forms.Label();
            this.dtpFrom       = new System.Windows.Forms.DateTimePicker();
            this.lblTo         = new System.Windows.Forms.Label();
            this.dtpTo         = new System.Windows.Forms.DateTimePicker();
            this.lblReportType = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerate   = new System.Windows.Forms.Button();
            this.btnExportCSV  = new System.Windows.Forms.Button();
            this.dgvReport     = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(136, 59, 47);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name     = "pnlHeader";
            this.pnlHeader.Size     = new System.Drawing.Size(960, 52);
            this.pnlHeader.TabIndex = 0;

            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Padding   = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblTitle.Size      = new System.Drawing.Size(200, 52);
            this.lblTitle.Text      = "Reports";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlFilters ───────────────────────────────────────────────
            this.pnlFilters.BackColor  = System.Drawing.Color.FromArgb(72, 72, 72);
            this.pnlFilters.Controls.Add(this.lblFrom);
            this.pnlFilters.Controls.Add(this.dtpFrom);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtpTo);
            this.pnlFilters.Controls.Add(this.lblReportType);
            this.pnlFilters.Controls.Add(this.cmbReportType);
            this.pnlFilters.Controls.Add(this.btnGenerate);
            this.pnlFilters.Controls.Add(this.btnExportCSV);
            this.pnlFilters.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Name       = "pnlFilters";
            this.pnlFilters.Size       = new System.Drawing.Size(960, 72);
            this.pnlFilters.TabIndex   = 1;

            this.lblFrom.AutoSize  = true;
            this.lblFrom.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrom.ForeColor = System.Drawing.Color.White;
            this.lblFrom.Location  = new System.Drawing.Point(16, 10);
            this.lblFrom.Name      = "lblFrom";
            this.lblFrom.Text      = "From";

            this.dtpFrom.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Location = new System.Drawing.Point(16, 28);
            this.dtpFrom.Name     = "dtpFrom";
            this.dtpFrom.Size     = new System.Drawing.Size(190, 26);
            this.dtpFrom.TabIndex = 0;

            this.lblTo.AutoSize  = true;
            this.lblTo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTo.ForeColor = System.Drawing.Color.White;
            this.lblTo.Location  = new System.Drawing.Point(224, 10);
            this.lblTo.Name      = "lblTo";
            this.lblTo.Text      = "To";

            this.dtpTo.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Location = new System.Drawing.Point(224, 28);
            this.dtpTo.Name     = "dtpTo";
            this.dtpTo.Size     = new System.Drawing.Size(190, 26);
            this.dtpTo.TabIndex = 1;

            this.lblReportType.AutoSize  = true;
            this.lblReportType.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReportType.ForeColor = System.Drawing.Color.White;
            this.lblReportType.Location  = new System.Drawing.Point(432, 10);
            this.lblReportType.Name      = "lblReportType";
            this.lblReportType.Text      = "Report Type";

            this.cmbReportType.BackColor     = System.Drawing.Color.FromArgb(82, 82, 82);
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FlatStyle      = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReportType.Font           = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbReportType.ForeColor      = System.Drawing.Color.White;
            this.cmbReportType.Items.AddRange(new object[] { "All Checkouts", "Value Summary" });
            this.cmbReportType.Location       = new System.Drawing.Point(432, 28);
            this.cmbReportType.Name           = "cmbReportType";
            this.cmbReportType.Size           = new System.Drawing.Size(200, 26);
            this.cmbReportType.TabIndex       = 2;

            this.btnGenerate.BackColor                 = System.Drawing.Color.FromArgb(136, 59, 47);
            this.btnGenerate.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font                      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor                 = System.Drawing.Color.White;
            this.btnGenerate.Location                  = new System.Drawing.Point(650, 22);
            this.btnGenerate.Name                      = "btnGenerate";
            this.btnGenerate.Size                      = new System.Drawing.Size(140, 36);
            this.btnGenerate.Text                      = "Generate";
            this.btnGenerate.UseVisualStyleBackColor   = false;
            this.btnGenerate.Click                    += new System.EventHandler(this.btnGenerate_Click);

            this.btnExportCSV.BackColor                 = System.Drawing.Color.FromArgb(50, 110, 50);
            this.btnExportCSV.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnExportCSV.FlatAppearance.BorderSize = 0;
            this.btnExportCSV.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Font                      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportCSV.ForeColor                 = System.Drawing.Color.White;
            this.btnExportCSV.Location                  = new System.Drawing.Point(800, 22);
            this.btnExportCSV.Name                      = "btnExportCSV";
            this.btnExportCSV.Size                      = new System.Drawing.Size(144, 36);
            this.btnExportCSV.Text                      = "Export to CSV";
            this.btnExportCSV.UseVisualStyleBackColor   = false;
            this.btnExportCSV.Click                    += new System.EventHandler(this.btnExportCSV_Click);

            // ── dgvReport ────────────────────────────────────────────────
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

            this.dgvReport.AllowUserToAddRows              = false;
            this.dgvReport.AllowUserToDeleteRows           = false;
            this.dgvReport.AlternatingRowsDefaultCellStyle = dgvAltCellStyle;
            this.dgvReport.AutoSizeColumnsMode             = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor                 = System.Drawing.Color.FromArgb(60, 60, 60);
            this.dgvReport.BorderStyle                     = System.Windows.Forms.BorderStyle.None;
            this.dgvReport.CellBorderStyle                 = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReport.ColumnHeadersDefaultCellStyle   = dgvHeaderStyle;
            this.dgvReport.ColumnHeadersHeightSizeMode     = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.DefaultCellStyle                = dgvCellStyle;
            this.dgvReport.Dock                            = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles       = false;
            this.dgvReport.GridColor                       = System.Drawing.Color.FromArgb(88, 88, 88);
            this.dgvReport.Name                            = "dgvReport";
            this.dgvReport.ReadOnly                        = true;
            this.dgvReport.RowHeadersVisible               = false;
            this.dgvReport.RowTemplate.Height              = 32;
            this.dgvReport.SelectionMode                   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.TabIndex                        = 2;

            // ── frmReports ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(60, 60, 60);
            this.ClientSize          = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "frmReports";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Reports";
            this.Load           += new System.EventHandler(this.frmReports_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Panel          pnlFilters;
        private System.Windows.Forms.Label          lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label          lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label          lblReportType;
        private System.Windows.Forms.ComboBox       cmbReportType;
        private System.Windows.Forms.Button         btnGenerate;
        private System.Windows.Forms.Button         btnExportCSV;
        private System.Windows.Forms.DataGridView   dgvReport;
    }
}
