namespace ElectronicsInventory
{
    // Layout: navy header (title + search) | horizontal field strip | full-width grid | bottom action bar
    partial class frmProjects
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

            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.txtSearch      = new System.Windows.Forms.TextBox();
            this.pnlForm        = new System.Windows.Forms.Panel();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectCode = new System.Windows.Forms.Label();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.lblLeadName    = new System.Windows.Forms.Label();
            this.txtLeadName    = new System.Windows.Forms.TextBox();
            this.lblEmail       = new System.Windows.Forms.Label();
            this.txtEmail       = new System.Windows.Forms.TextBox();
            this.dgvProjects    = new System.Windows.Forms.DataGridView();
            this.pnlActions     = new System.Windows.Forms.Panel();
            this.btnAdd         = new System.Windows.Forms.Button();
            this.btnUpdate      = new System.Windows.Forms.Button();
            this.btnDelete      = new System.Windows.Forms.Button();
            this.btnClear       = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
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
            this.lblTitle.Size      = new System.Drawing.Size(260, 52);
            this.lblTitle.Text      = "Project Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtSearch.BackColor       = System.Drawing.Color.FromArgb(25, 85, 170);
            this.txtSearch.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor       = System.Drawing.Color.White;
            this.txtSearch.Location        = new System.Drawing.Point(660, 14);
            this.txtSearch.Name            = "txtSearch";
            this.txtSearch.PlaceholderText = "Search projects...";
            this.txtSearch.Size            = new System.Drawing.Size(280, 24);
            this.txtSearch.TabIndex        = 10;
            this.txtSearch.TextChanged    += new System.EventHandler(this.txtSearch_TextChanged);

            // ── pnlForm (single-row horizontal field strip) ──────────────
            this.pnlForm.BackColor  = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlForm.Controls.Add(this.lblProjectName);
            this.pnlForm.Controls.Add(this.txtProjectName);
            this.pnlForm.Controls.Add(this.lblProjectCode);
            this.pnlForm.Controls.Add(this.txtProjectCode);
            this.pnlForm.Controls.Add(this.lblLeadName);
            this.pnlForm.Controls.Add(this.txtLeadName);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Name       = "pnlForm";
            this.pnlForm.Size       = new System.Drawing.Size(960, 68);
            this.pnlForm.TabIndex   = 1;

            // Row 1 — Project Name | Project Code | Lead Name | Email
            this.lblProjectName.AutoSize  = true;
            this.lblProjectName.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProjectName.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblProjectName.Location  = new System.Drawing.Point(16, 10);
            this.lblProjectName.Name      = "lblProjectName";
            this.lblProjectName.Text      = "Project Name";

            this.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectName.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProjectName.Location    = new System.Drawing.Point(16, 28);
            this.txtProjectName.Name        = "txtProjectName";
            this.txtProjectName.Size        = new System.Drawing.Size(230, 26);
            this.txtProjectName.TabIndex    = 0;

            this.lblProjectCode.AutoSize  = true;
            this.lblProjectCode.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProjectCode.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblProjectCode.Location  = new System.Drawing.Point(264, 10);
            this.lblProjectCode.Name      = "lblProjectCode";
            this.lblProjectCode.Text      = "Project Code";

            this.txtProjectCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectCode.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProjectCode.Location    = new System.Drawing.Point(264, 28);
            this.txtProjectCode.Name        = "txtProjectCode";
            this.txtProjectCode.Size        = new System.Drawing.Size(180, 26);
            this.txtProjectCode.TabIndex    = 1;

            this.lblLeadName.AutoSize  = true;
            this.lblLeadName.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLeadName.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblLeadName.Location  = new System.Drawing.Point(462, 10);
            this.lblLeadName.Name      = "lblLeadName";
            this.lblLeadName.Text      = "Lead Name";

            this.txtLeadName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeadName.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLeadName.Location    = new System.Drawing.Point(462, 28);
            this.txtLeadName.Name        = "txtLeadName";
            this.txtLeadName.Size        = new System.Drawing.Size(220, 26);
            this.txtLeadName.TabIndex    = 2;

            this.lblEmail.AutoSize  = true;
            this.lblEmail.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblEmail.Location  = new System.Drawing.Point(700, 10);
            this.lblEmail.Name      = "lblEmail";
            this.lblEmail.Text      = "Email";

            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location    = new System.Drawing.Point(700, 28);
            this.txtEmail.Name        = "txtEmail";
            this.txtEmail.Size        = new System.Drawing.Size(244, 26);
            this.txtEmail.TabIndex    = 3;

            // ── dgvProjects (fills space between field strip and action bar) ──
            this.dgvProjects.AllowUserToAddRows    = false;
            this.dgvProjects.AllowUserToDeleteRows = false;
            this.dgvProjects.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjects.BackgroundColor       = System.Drawing.Color.White;
            this.dgvProjects.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvProjects.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            dgvHeaderStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProjects.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvProjects.ColumnHeadersHeightSizeMode   = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjects.Dock                          = System.Windows.Forms.DockStyle.Fill;
            this.dgvProjects.EnableHeadersVisualStyles     = false;
            this.dgvProjects.GridColor                     = System.Drawing.Color.FromArgb(224, 224, 224);
            this.dgvProjects.Name                          = "dgvProjects";
            this.dgvProjects.ReadOnly                      = true;
            this.dgvProjects.RowHeadersVisible             = false;
            this.dgvProjects.RowTemplate.Height            = 32;
            this.dgvProjects.SelectionMode                 = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjects.TabIndex                      = 2;
            this.dgvProjects.SelectionChanged             += new System.EventHandler(this.dgvProjects_SelectionChanged);

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

            // ── frmProjects ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.dgvProjects);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "frmProjects";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Projects";
            this.Load           += new System.EventHandler(this.frmProjects_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel        pnlHeader;
        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.TextBox      txtSearch;
        private System.Windows.Forms.Panel        pnlForm;
        private System.Windows.Forms.Label        lblProjectName;
        private System.Windows.Forms.TextBox      txtProjectName;
        private System.Windows.Forms.Label        lblProjectCode;
        private System.Windows.Forms.TextBox      txtProjectCode;
        private System.Windows.Forms.Label        lblLeadName;
        private System.Windows.Forms.TextBox      txtLeadName;
        private System.Windows.Forms.Label        lblEmail;
        private System.Windows.Forms.TextBox      txtEmail;
        private System.Windows.Forms.DataGridView dgvProjects;
        private System.Windows.Forms.Panel        pnlActions;
        private System.Windows.Forms.Button       btnAdd;
        private System.Windows.Forms.Button       btnUpdate;
        private System.Windows.Forms.Button       btnDelete;
        private System.Windows.Forms.Button       btnClear;
    }
}
