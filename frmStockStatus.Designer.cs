namespace ElectronicsInventory
{
    partial class frmStockStatus
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

            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblTitle     = new System.Windows.Forms.Label();
            this.pnlFilters   = new System.Windows.Forms.Panel();
            this.lblStart     = new System.Windows.Forms.Label();
            this.dtpStart     = new System.Windows.Forms.DateTimePicker();
            this.lblEnd       = new System.Windows.Forms.Label();
            this.dtpEnd       = new System.Windows.Forms.DateTimePicker();
            this.btnCheck     = new System.Windows.Forms.Button();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(136, 59, 47);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name     = "pnlHeader";
            this.pnlHeader.Size     = new System.Drawing.Size(860, 52);
            this.pnlHeader.TabIndex = 0;

            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Padding   = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblTitle.Size      = new System.Drawing.Size(360, 52);
            this.lblTitle.Text      = "Check Component Availability";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlFilters ───────────────────────────────────────────────
            this.pnlFilters.BackColor  = System.Drawing.Color.FromArgb(72, 72, 72);
            this.pnlFilters.Controls.Add(this.lblStart);
            this.pnlFilters.Controls.Add(this.dtpStart);
            this.pnlFilters.Controls.Add(this.lblEnd);
            this.pnlFilters.Controls.Add(this.dtpEnd);
            this.pnlFilters.Controls.Add(this.btnCheck);
            this.pnlFilters.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Name       = "pnlFilters";
            this.pnlFilters.Size       = new System.Drawing.Size(860, 72);
            this.pnlFilters.TabIndex   = 1;

            this.lblStart.AutoSize  = true;
            this.lblStart.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStart.ForeColor = System.Drawing.Color.White;
            this.lblStart.Location  = new System.Drawing.Point(16, 10);
            this.lblStart.Name      = "lblStart";
            this.lblStart.Text      = "Start Date";

            this.dtpStart.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStart.Location = new System.Drawing.Point(16, 28);
            this.dtpStart.Name     = "dtpStart";
            this.dtpStart.Size     = new System.Drawing.Size(200, 26);
            this.dtpStart.TabIndex = 0;

            this.lblEnd.AutoSize  = true;
            this.lblEnd.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEnd.ForeColor = System.Drawing.Color.White;
            this.lblEnd.Location  = new System.Drawing.Point(234, 10);
            this.lblEnd.Name      = "lblEnd";
            this.lblEnd.Text      = "End Date";

            this.dtpEnd.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEnd.Location = new System.Drawing.Point(234, 28);
            this.dtpEnd.Name     = "dtpEnd";
            this.dtpEnd.Size     = new System.Drawing.Size(200, 26);
            this.dtpEnd.TabIndex = 1;

            this.btnCheck.BackColor                 = System.Drawing.Color.FromArgb(136, 59, 47);
            this.btnCheck.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font                      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheck.ForeColor                 = System.Drawing.Color.White;
            this.btnCheck.Location                  = new System.Drawing.Point(452, 22);
            this.btnCheck.Name                      = "btnCheck";
            this.btnCheck.Size                      = new System.Drawing.Size(200, 36);
            this.btnCheck.Text                      = "Check Availability";
            this.btnCheck.UseVisualStyleBackColor   = false;
            this.btnCheck.Click                    += new System.EventHandler(this.btnCheck_Click);

            // ── dgvAvailable ─────────────────────────────────────────────
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

            this.dgvAvailable.AllowUserToAddRows              = false;
            this.dgvAvailable.AllowUserToDeleteRows           = false;
            this.dgvAvailable.AlternatingRowsDefaultCellStyle = dgvAltCellStyle;
            this.dgvAvailable.AutoSizeColumnsMode             = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailable.BackgroundColor                 = System.Drawing.Color.FromArgb(60, 60, 60);
            this.dgvAvailable.BorderStyle                     = System.Windows.Forms.BorderStyle.None;
            this.dgvAvailable.CellBorderStyle                 = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAvailable.ColumnHeadersDefaultCellStyle   = dgvHeaderStyle;
            this.dgvAvailable.ColumnHeadersHeightSizeMode     = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailable.DefaultCellStyle                = dgvCellStyle;
            this.dgvAvailable.Dock                            = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailable.EnableHeadersVisualStyles       = false;
            this.dgvAvailable.GridColor                       = System.Drawing.Color.FromArgb(88, 88, 88);
            this.dgvAvailable.Name                            = "dgvAvailable";
            this.dgvAvailable.ReadOnly                        = true;
            this.dgvAvailable.RowHeadersVisible               = false;
            this.dgvAvailable.RowTemplate.Height              = 32;
            this.dgvAvailable.SelectionMode                   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailable.TabIndex                        = 2;

            // ── frmStockStatus ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(60, 60, 60);
            this.ClientSize          = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.dgvAvailable);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "frmStockStatus";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Stock Status";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Panel          pnlFilters;
        private System.Windows.Forms.Label          lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label          lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button         btnCheck;
        private System.Windows.Forms.DataGridView   dgvAvailable;
    }
}
