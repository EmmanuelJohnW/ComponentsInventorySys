namespace ElectronicsInventory
{
    // Layout: dark header band (title) | top form panel (filters row) | full-width checkout grid
    partial class frmCheckouts
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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.lblTitle        = new System.Windows.Forms.Label();
            this.pnlForm         = new System.Windows.Forms.Panel();
            this.lblComponent    = new System.Windows.Forms.Label();
            this.cmbComponent    = new System.Windows.Forms.ComboBox();
            this.lblProject      = new System.Windows.Forms.Label();
            this.cmbProject      = new System.Windows.Forms.ComboBox();
            this.lblCheckoutDate = new System.Windows.Forms.Label();
            this.dtpCheckoutDate = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate   = new System.Windows.Forms.Label();
            this.dtpReturnDate   = new System.Windows.Forms.DateTimePicker();
            this.lblUnitValue    = new System.Windows.Forms.Label();
            this.txtUnitValue    = new System.Windows.Forms.TextBox();
            this.btnSaveCheckout = new System.Windows.Forms.Button();
            this.dgvCheckouts    = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckouts)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
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
            this.lblTitle.Size      = new System.Drawing.Size(300, 52);
            this.lblTitle.Text      = "Component Checkout";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlForm ──────────────────────────────────────────────────
            this.pnlForm.BackColor  = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlForm.Controls.Add(this.lblComponent);
            this.pnlForm.Controls.Add(this.cmbComponent);
            this.pnlForm.Controls.Add(this.lblProject);
            this.pnlForm.Controls.Add(this.cmbProject);
            this.pnlForm.Controls.Add(this.lblCheckoutDate);
            this.pnlForm.Controls.Add(this.dtpCheckoutDate);
            this.pnlForm.Controls.Add(this.lblReturnDate);
            this.pnlForm.Controls.Add(this.dtpReturnDate);
            this.pnlForm.Controls.Add(this.lblUnitValue);
            this.pnlForm.Controls.Add(this.txtUnitValue);
            this.pnlForm.Controls.Add(this.btnSaveCheckout);
            this.pnlForm.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Name       = "pnlForm";
            this.pnlForm.Size       = new System.Drawing.Size(960, 170);
            this.pnlForm.TabIndex   = 1;

            // Row 1: Component (col 0) | Project (col 1)
            this.lblComponent.AutoSize  = true;
            this.lblComponent.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblComponent.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblComponent.Location  = new System.Drawing.Point(16, 14);
            this.lblComponent.Name      = "lblComponent";
            this.lblComponent.Text      = "Component";

            this.cmbComponent.DropDownStyle        = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComponent.FlatStyle             = System.Windows.Forms.FlatStyle.Flat;
            this.cmbComponent.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbComponent.Location              = new System.Drawing.Point(16, 32);
            this.cmbComponent.Name                  = "cmbComponent";
            this.cmbComponent.Size                  = new System.Drawing.Size(300, 26);
            this.cmbComponent.TabIndex              = 0;
            this.cmbComponent.SelectedIndexChanged += new System.EventHandler(this.cmbComponent_SelectedIndexChanged);

            this.lblProject.AutoSize  = true;
            this.lblProject.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProject.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblProject.Location  = new System.Drawing.Point(334, 14);
            this.lblProject.Name      = "lblProject";
            this.lblProject.Text      = "Project";

            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FlatStyle      = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProject.Font           = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProject.Location       = new System.Drawing.Point(334, 32);
            this.cmbProject.Name           = "cmbProject";
            this.cmbProject.Size           = new System.Drawing.Size(280, 26);
            this.cmbProject.TabIndex       = 1;

            // Row 2: Checkout Date | Return Date | Unit Value | Save button
            this.lblCheckoutDate.AutoSize  = true;
            this.lblCheckoutDate.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckoutDate.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblCheckoutDate.Location  = new System.Drawing.Point(16, 74);
            this.lblCheckoutDate.Name      = "lblCheckoutDate";
            this.lblCheckoutDate.Text      = "Checkout Date";

            this.dtpCheckoutDate.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckoutDate.Location = new System.Drawing.Point(16, 92);
            this.dtpCheckoutDate.Name     = "dtpCheckoutDate";
            this.dtpCheckoutDate.Size     = new System.Drawing.Size(180, 26);
            this.dtpCheckoutDate.TabIndex = 2;

            this.lblReturnDate.AutoSize  = true;
            this.lblReturnDate.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReturnDate.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblReturnDate.Location  = new System.Drawing.Point(214, 74);
            this.lblReturnDate.Name      = "lblReturnDate";
            this.lblReturnDate.Text      = "Return Date";

            this.dtpReturnDate.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReturnDate.Location = new System.Drawing.Point(214, 92);
            this.dtpReturnDate.Name     = "dtpReturnDate";
            this.dtpReturnDate.Size     = new System.Drawing.Size(180, 26);
            this.dtpReturnDate.TabIndex = 3;

            this.lblUnitValue.AutoSize  = true;
            this.lblUnitValue.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnitValue.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblUnitValue.Location  = new System.Drawing.Point(412, 74);
            this.lblUnitValue.Name      = "lblUnitValue";
            this.lblUnitValue.Text      = "Unit Value";

            this.txtUnitValue.BackColor    = System.Drawing.Color.FromArgb(227, 242, 253);
            this.txtUnitValue.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitValue.Font         = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUnitValue.Location     = new System.Drawing.Point(412, 92);
            this.txtUnitValue.Name         = "txtUnitValue";
            this.txtUnitValue.ReadOnly     = true;
            this.txtUnitValue.Size         = new System.Drawing.Size(160, 26);
            this.txtUnitValue.TabIndex     = 4;

            this.btnSaveCheckout.BackColor                 = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnSaveCheckout.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnSaveCheckout.FlatAppearance.BorderSize = 0;
            this.btnSaveCheckout.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCheckout.Font                      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveCheckout.ForeColor                 = System.Drawing.Color.White;
            this.btnSaveCheckout.Location                  = new System.Drawing.Point(590, 86);
            this.btnSaveCheckout.Name                      = "btnSaveCheckout";
            this.btnSaveCheckout.Size                      = new System.Drawing.Size(180, 38);
            this.btnSaveCheckout.Text                      = "Save Checkout";
            this.btnSaveCheckout.UseVisualStyleBackColor   = false;
            this.btnSaveCheckout.Click                    += new System.EventHandler(this.btnSaveCheckout_Click);

            // ── dgvCheckouts ─────────────────────────────────────────────
            this.dgvCheckouts.AllowUserToAddRows    = false;
            this.dgvCheckouts.AllowUserToDeleteRows = false;
            this.dgvCheckouts.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCheckouts.BackgroundColor       = System.Drawing.Color.White;
            this.dgvCheckouts.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvCheckouts.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            dgvHeaderStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCheckouts.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvCheckouts.ColumnHeadersHeightSizeMode   = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckouts.Dock                          = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckouts.EnableHeadersVisualStyles     = false;
            this.dgvCheckouts.GridColor                     = System.Drawing.Color.FromArgb(224, 224, 224);
            this.dgvCheckouts.Name                          = "dgvCheckouts";
            this.dgvCheckouts.ReadOnly                      = true;
            this.dgvCheckouts.RowHeadersVisible             = false;
            this.dgvCheckouts.RowTemplate.Height            = 32;
            this.dgvCheckouts.SelectionMode                 = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckouts.TabIndex                      = 2;

            // ── frmCheckouts ─────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.dgvCheckouts);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "frmCheckouts";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Checkouts";
            this.Load           += new System.EventHandler(this.frmCheckouts_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckouts)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Panel          pnlForm;
        private System.Windows.Forms.Label          lblComponent;
        private System.Windows.Forms.ComboBox       cmbComponent;
        private System.Windows.Forms.Label          lblProject;
        private System.Windows.Forms.ComboBox       cmbProject;
        private System.Windows.Forms.Label          lblCheckoutDate;
        private System.Windows.Forms.DateTimePicker dtpCheckoutDate;
        private System.Windows.Forms.Label          lblReturnDate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label          lblUnitValue;
        private System.Windows.Forms.TextBox        txtUnitValue;
        private System.Windows.Forms.Button         btnSaveCheckout;
        private System.Windows.Forms.DataGridView   dgvCheckouts;
    }
}
