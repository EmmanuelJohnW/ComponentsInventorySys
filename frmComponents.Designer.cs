namespace ElectronicsInventory
{
    // Layout: navy header (title + search) | horizontal field strip | full-width grid | bottom action bar
    partial class frmComponents
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
            this.txtSearch       = new System.Windows.Forms.TextBox();
            this.pnlForm         = new System.Windows.Forms.Panel();
            this.lblPartNo       = new System.Windows.Forms.Label();
            this.txtPartNo       = new System.Windows.Forms.TextBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.lblPartName     = new System.Windows.Forms.Label();
            this.txtPartName     = new System.Windows.Forms.TextBox();
            this.lblStatus       = new System.Windows.Forms.Label();
            this.cmbStatus       = new System.Windows.Forms.ComboBox();
            this.lblQty          = new System.Windows.Forms.Label();
            this.txtQty          = new System.Windows.Forms.TextBox();
            this.lblUnitCost     = new System.Windows.Forms.Label();
            this.txtUnitCost     = new System.Windows.Forms.TextBox();
            this.dgvComponents   = new System.Windows.Forms.DataGridView();
            this.pnlActions      = new System.Windows.Forms.Panel();
            this.btnAdd          = new System.Windows.Forms.Button();
            this.btnUpdate       = new System.Windows.Forms.Button();
            this.btnDelete       = new System.Windows.Forms.Button();
            this.btnClear        = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.txtSearch);
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
            this.lblTitle.Size      = new System.Drawing.Size(280, 52);
            this.lblTitle.Text      = "Component Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtSearch.BackColor       = System.Drawing.Color.FromArgb(25, 85, 170);
            this.txtSearch.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor       = System.Drawing.Color.White;
            this.txtSearch.Location        = new System.Drawing.Point(660, 14);
            this.txtSearch.Name            = "txtSearch";
            this.txtSearch.PlaceholderText = "Search components...";
            this.txtSearch.Size            = new System.Drawing.Size(280, 24);
            this.txtSearch.TabIndex        = 10;
            this.txtSearch.TextChanged    += new System.EventHandler(this.txtSearch_TextChanged);

            // ── pnlForm (horizontal field strip below header) ────────────
            this.pnlForm.BackColor  = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlForm.Controls.Add(this.lblPartNo);
            this.pnlForm.Controls.Add(this.txtPartNo);
            this.pnlForm.Controls.Add(this.lblManufacturer);
            this.pnlForm.Controls.Add(this.txtManufacturer);
            this.pnlForm.Controls.Add(this.lblPartName);
            this.pnlForm.Controls.Add(this.txtPartName);
            this.pnlForm.Controls.Add(this.lblStatus);
            this.pnlForm.Controls.Add(this.cmbStatus);
            this.pnlForm.Controls.Add(this.lblQty);
            this.pnlForm.Controls.Add(this.txtQty);
            this.pnlForm.Controls.Add(this.lblUnitCost);
            this.pnlForm.Controls.Add(this.txtUnitCost);
            this.pnlForm.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Name       = "pnlForm";
            this.pnlForm.Size       = new System.Drawing.Size(960, 120);
            this.pnlForm.TabIndex   = 1;

            // Row 1 — Part No. | Manufacturer | Part Name | Status
            this.lblPartNo.AutoSize  = true;
            this.lblPartNo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPartNo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPartNo.Location  = new System.Drawing.Point(16, 10);
            this.lblPartNo.Name      = "lblPartNo";
            this.lblPartNo.Text      = "Part No.";

            this.txtPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartNo.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPartNo.Location    = new System.Drawing.Point(16, 28);
            this.txtPartNo.Name        = "txtPartNo";
            this.txtPartNo.Size        = new System.Drawing.Size(160, 26);
            this.txtPartNo.TabIndex    = 0;

            this.lblManufacturer.AutoSize  = true;
            this.lblManufacturer.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblManufacturer.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblManufacturer.Location  = new System.Drawing.Point(194, 10);
            this.lblManufacturer.Name      = "lblManufacturer";
            this.lblManufacturer.Text      = "Manufacturer";

            this.txtManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManufacturer.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtManufacturer.Location    = new System.Drawing.Point(194, 28);
            this.txtManufacturer.Name        = "txtManufacturer";
            this.txtManufacturer.Size        = new System.Drawing.Size(200, 26);
            this.txtManufacturer.TabIndex    = 1;

            this.lblPartName.AutoSize  = true;
            this.lblPartName.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPartName.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPartName.Location  = new System.Drawing.Point(412, 10);
            this.lblPartName.Name      = "lblPartName";
            this.lblPartName.Text      = "Part Name";

            this.txtPartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartName.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPartName.Location    = new System.Drawing.Point(412, 28);
            this.txtPartName.Name        = "txtPartName";
            this.txtPartName.Size        = new System.Drawing.Size(280, 26);
            this.txtPartName.TabIndex    = 2;

            this.lblStatus.AutoSize  = true;
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblStatus.Location  = new System.Drawing.Point(710, 10);
            this.lblStatus.Name      = "lblStatus";
            this.lblStatus.Text      = "Status";

            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.Items.AddRange(new object[] { "In Stock", "Checked Out", "Defective" });
            this.cmbStatus.Location      = new System.Drawing.Point(710, 28);
            this.cmbStatus.Name          = "cmbStatus";
            this.cmbStatus.Size          = new System.Drawing.Size(230, 26);
            this.cmbStatus.TabIndex      = 3;

            // Row 2 — Qty | Unit Cost
            this.lblQty.AutoSize  = true;
            this.lblQty.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQty.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblQty.Location  = new System.Drawing.Point(16, 66);
            this.lblQty.Name      = "lblQty";
            this.lblQty.Text      = "Qty";

            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQty.Location    = new System.Drawing.Point(16, 84);
            this.txtQty.Name        = "txtQty";
            this.txtQty.Size        = new System.Drawing.Size(120, 26);
            this.txtQty.TabIndex    = 4;

            this.lblUnitCost.AutoSize  = true;
            this.lblUnitCost.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnitCost.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblUnitCost.Location  = new System.Drawing.Point(154, 66);
            this.lblUnitCost.Name      = "lblUnitCost";
            this.lblUnitCost.Text      = "Unit Cost";

            this.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitCost.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUnitCost.Location    = new System.Drawing.Point(154, 84);
            this.txtUnitCost.Name        = "txtUnitCost";
            this.txtUnitCost.Size        = new System.Drawing.Size(160, 26);
            this.txtUnitCost.TabIndex    = 5;

            // ── dgvComponents (fills space between form strip and action bar) ──
            this.dgvComponents.AllowUserToAddRows    = false;
            this.dgvComponents.AllowUserToDeleteRows = false;
            this.dgvComponents.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComponents.BackgroundColor       = System.Drawing.Color.White;
            this.dgvComponents.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvComponents.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            dgvHeaderStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvComponents.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvComponents.ColumnHeadersHeightSizeMode   = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponents.Dock                          = System.Windows.Forms.DockStyle.Fill;
            this.dgvComponents.EnableHeadersVisualStyles     = false;
            this.dgvComponents.GridColor                     = System.Drawing.Color.FromArgb(224, 224, 224);
            this.dgvComponents.Name                          = "dgvComponents";
            this.dgvComponents.ReadOnly                      = true;
            this.dgvComponents.RowHeadersVisible             = false;
            this.dgvComponents.RowTemplate.Height            = 32;
            this.dgvComponents.SelectionMode                 = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComponents.TabIndex                      = 2;
            this.dgvComponents.SelectionChanged             += new System.EventHandler(this.dgvComponents_SelectionChanged);

            // ── pnlActions (bottom button bar) ───────────────────────────
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Controls.Add(this.btnUpdate);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnClear);
            this.pnlActions.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Name      = "pnlActions";
            this.pnlActions.Size      = new System.Drawing.Size(960, 58);
            this.pnlActions.TabIndex  = 3;

            this.btnAdd.BackColor                 = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnAdd.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font                      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor                 = System.Drawing.Color.White;
            this.btnAdd.Location                  = new System.Drawing.Point(16, 10);
            this.btnAdd.Name                      = "btnAdd";
            this.btnAdd.Size                      = new System.Drawing.Size(130, 36);
            this.btnAdd.Text                      = "Add";
            this.btnAdd.UseVisualStyleBackColor   = false;
            this.btnAdd.Click                    += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.BackColor                 = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnUpdate.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font                      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor                 = System.Drawing.Color.White;
            this.btnUpdate.Location                  = new System.Drawing.Point(158, 10);
            this.btnUpdate.Name                      = "btnUpdate";
            this.btnUpdate.Size                      = new System.Drawing.Size(130, 36);
            this.btnUpdate.Text                      = "Update";
            this.btnUpdate.UseVisualStyleBackColor   = false;
            this.btnUpdate.Click                    += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.BackColor                 = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnDelete.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font                      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor                 = System.Drawing.Color.White;
            this.btnDelete.Location                  = new System.Drawing.Point(300, 10);
            this.btnDelete.Name                      = "btnDelete";
            this.btnDelete.Size                      = new System.Drawing.Size(130, 36);
            this.btnDelete.Text                      = "Delete";
            this.btnDelete.UseVisualStyleBackColor   = false;
            this.btnDelete.Click                    += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.BackColor                 = System.Drawing.Color.FromArgb(97, 97, 97);
            this.btnClear.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font                      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor                 = System.Drawing.Color.White;
            this.btnClear.Location                  = new System.Drawing.Point(442, 10);
            this.btnClear.Name                      = "btnClear";
            this.btnClear.Size                      = new System.Drawing.Size(130, 36);
            this.btnClear.Text                      = "Clear";
            this.btnClear.UseVisualStyleBackColor   = false;
            this.btnClear.Click                    += new System.EventHandler(this.btnClear_Click);

            // ── frmComponents ────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.dgvComponents);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "frmComponents";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Components";
            this.Load           += new System.EventHandler(this.frmComponents_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel        pnlHeader;
        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.TextBox      txtSearch;
        private System.Windows.Forms.Panel        pnlForm;
        private System.Windows.Forms.Label        lblPartNo;
        private System.Windows.Forms.TextBox      txtPartNo;
        private System.Windows.Forms.Label        lblManufacturer;
        private System.Windows.Forms.TextBox      txtManufacturer;
        private System.Windows.Forms.Label        lblPartName;
        private System.Windows.Forms.TextBox      txtPartName;
        private System.Windows.Forms.Label        lblStatus;
        private System.Windows.Forms.ComboBox     cmbStatus;
        private System.Windows.Forms.Label        lblQty;
        private System.Windows.Forms.TextBox      txtQty;
        private System.Windows.Forms.Label        lblUnitCost;
        private System.Windows.Forms.TextBox      txtUnitCost;
        private System.Windows.Forms.DataGridView dgvComponents;
        private System.Windows.Forms.Panel        pnlActions;
        private System.Windows.Forms.Button       btnAdd;
        private System.Windows.Forms.Button       btnUpdate;
        private System.Windows.Forms.Button       btnDelete;
        private System.Windows.Forms.Button       btnClear;
    }
}
