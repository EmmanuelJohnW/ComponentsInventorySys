
namespace ElectronicsInventory
{
    partial class frmLogin
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
            pnlLeft     = new Panel();
            picLogo     = new PictureBox();
            lblAppName  = new Label();
            lblTagline  = new Label();
            pnlRight    = new Panel();
            lblSignIn   = new Label();
            lblSubtitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin    = new Button();
            lblError    = new Label();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picLogo)).BeginInit();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // ── pnlLeft ─────────────────────────────────────────────────
            pnlLeft.BackColor = Color.FromArgb(50, 50, 50);
            pnlLeft.Controls.Add(picLogo);
            pnlLeft.Controls.Add(lblAppName);
            pnlLeft.Controls.Add(lblTagline);
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name     = "pnlLeft";
            pnlLeft.Size     = new Size(310, 520);
            pnlLeft.TabIndex = 0;
            // ── picLogo ──────────────────────────────────────────────────
            picLogo.BackColor = Color.Transparent;
            picLogo.Location  = new Point(95, 75);
            picLogo.Name      = "picLogo";
            picLogo.Size      = new Size(120, 120);
            picLogo.SizeMode  = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex  = 2;
            picLogo.TabStop   = false;
            // ── lblAppName ───────────────────────────────────────────────
            lblAppName.Font      = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblAppName.ForeColor = Color.FromArgb(136, 59, 47);
            lblAppName.Location  = new Point(10, 215);
            lblAppName.Name      = "lblAppName";
            lblAppName.Size      = new Size(290, 90);
            lblAppName.TabIndex  = 0;
            lblAppName.Text      = "ELECTRONICS\nINVENTORY\nSYSTEM";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // ── lblTagline ───────────────────────────────────────────────
            lblTagline.Font      = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblTagline.ForeColor = Color.FromArgb(160, 160, 160);
            lblTagline.Location  = new Point(10, 318);
            lblTagline.Name      = "lblTagline";
            lblTagline.Size      = new Size(290, 35);
            lblTagline.TabIndex  = 1;
            lblTagline.Text      = "Robotics && Embedded Components";
            lblTagline.TextAlign = ContentAlignment.MiddleCenter;
            // ── pnlRight ────────────────────────────────────────────────
            pnlRight.BackColor = Color.FromArgb(68, 68, 68);
            pnlRight.Controls.Add(lblSignIn);
            pnlRight.Controls.Add(lblSubtitle);
            pnlRight.Controls.Add(lblUsername);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(lblError);
            pnlRight.Location = new Point(310, 0);
            pnlRight.Name     = "pnlRight";
            pnlRight.Size     = new Size(450, 520);
            pnlRight.TabIndex = 1;
            // ── lblSignIn ────────────────────────────────────────────────
            lblSignIn.AutoSize  = false;
            lblSignIn.Font      = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblSignIn.ForeColor = Color.White;
            lblSignIn.Location  = new Point(40, 75);
            lblSignIn.Name      = "lblSignIn";
            lblSignIn.Size      = new Size(370, 50);
            lblSignIn.TabIndex  = 0;
            lblSignIn.Text      = "SIGN IN";
            // ── lblSubtitle ──────────────────────────────────────────────
            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtitle.ForeColor = Color.FromArgb(180, 180, 180);
            lblSubtitle.Location  = new Point(40, 128);
            lblSubtitle.Name      = "lblSubtitle";
            lblSubtitle.TabIndex  = 7;
            lblSubtitle.Text      = "Enter your credentials to access the system";
            // ── lblUsername ──────────────────────────────────────────────
            lblUsername.AutoSize  = true;
            lblUsername.Font      = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(200, 200, 200);
            lblUsername.Location  = new Point(40, 165);
            lblUsername.Name      = "lblUsername";
            lblUsername.TabIndex  = 1;
            lblUsername.Text      = "USERNAME";
            // ── txtUsername ──────────────────────────────────────────────
            txtUsername.BackColor   = Color.FromArgb(82, 82, 82);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font        = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.ForeColor   = Color.White;
            txtUsername.Location    = new Point(40, 183);
            txtUsername.Name        = "txtUsername";
            txtUsername.Size        = new Size(370, 28);
            txtUsername.TabIndex    = 2;
            // ── lblPassword ──────────────────────────────────────────────
            lblPassword.AutoSize  = true;
            lblPassword.Font      = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(200, 200, 200);
            lblPassword.Location  = new Point(40, 233);
            lblPassword.Name      = "lblPassword";
            lblPassword.TabIndex  = 3;
            lblPassword.Text      = "PASSWORD";
            // ── txtPassword ──────────────────────────────────────────────
            txtPassword.BackColor    = Color.FromArgb(82, 82, 82);
            txtPassword.BorderStyle  = BorderStyle.FixedSingle;
            txtPassword.Font         = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor    = Color.White;
            txtPassword.Location     = new Point(40, 251);
            txtPassword.Name         = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size         = new Size(370, 28);
            txtPassword.TabIndex     = 4;
            // ── btnLogin ─────────────────────────────────────────────────
            btnLogin.BackColor                 = Color.FromArgb(136, 59, 47);
            btnLogin.Cursor                    = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle                 = FlatStyle.Flat;
            btnLogin.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor                 = Color.White;
            btnLogin.Location                  = new Point(40, 315);
            btnLogin.Name                      = "btnLogin";
            btnLogin.Size                      = new Size(370, 46);
            btnLogin.TabIndex                  = 5;
            btnLogin.Text                      = "ACCESS SYSTEM";
            btnLogin.UseVisualStyleBackColor   = false;
            btnLogin.Click                    += btnLogin_Click;
            // ── lblError ─────────────────────────────────────────────────
            lblError.AutoSize  = true;
            lblError.Font      = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblError.ForeColor = Color.FromArgb(220, 70, 70);
            lblError.Location  = new Point(40, 376);
            lblError.Name      = "lblError";
            lblError.TabIndex  = 6;
            lblError.Text      = "Invalid username or password.";
            lblError.Visible   = false;
            // ── frmLogin ─────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(50, 50, 50);
            ClientSize          = new Size(760, 520);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            Name            = "frmLogin";
            StartPosition   = FormStartPosition.CenterScreen;
            Text            = "Electronics Inventory System";
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(picLogo)).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel       pnlLeft;
        private System.Windows.Forms.PictureBox  picLogo;
        private System.Windows.Forms.Label       lblAppName;
        private System.Windows.Forms.Label       lblTagline;
        private System.Windows.Forms.Panel       pnlRight;
        private System.Windows.Forms.Label       lblSignIn;
        private System.Windows.Forms.Label       lblSubtitle;
        private System.Windows.Forms.Label       lblUsername;
        private System.Windows.Forms.TextBox     txtUsername;
        private System.Windows.Forms.Label       lblPassword;
        private System.Windows.Forms.TextBox     txtPassword;
        private System.Windows.Forms.Button      btnLogin;
        private System.Windows.Forms.Label       lblError;
        private EventHandler frmLogin_Load;
    }
}
