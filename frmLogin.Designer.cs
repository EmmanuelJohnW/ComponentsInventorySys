
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

        // Split-panel layout: dark navy left brand panel + white right sign-in panel.
        private void InitializeComponent()
        {
            pnlLeft     = new Panel();
            lblAppName  = new Label();
            lblTagline  = new Label();
            pnlRight    = new Panel();
            lblSignIn   = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin    = new Button();
            lblError    = new Label();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // ── pnlLeft ─────────────────────────────────────────────────
            pnlLeft.BackColor = Color.FromArgb(13, 71, 161);
            pnlLeft.Controls.Add(lblTagline);
            pnlLeft.Controls.Add(lblAppName);
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name     = "pnlLeft";
            pnlLeft.Size     = new Size(270, 480);
            pnlLeft.TabIndex = 0;
            // ── lblAppName ───────────────────────────────────────────────
            lblAppName.Font      = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location  = new Point(15, 130);
            lblAppName.Name      = "lblAppName";
            lblAppName.Size      = new Size(240, 110);
            lblAppName.TabIndex  = 0;
            lblAppName.Text      = "Electronics\nInventory\nSystem";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // ── lblTagline ───────────────────────────────────────────────
            lblTagline.Font      = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTagline.ForeColor = Color.FromArgb(176, 199, 235);
            lblTagline.Location  = new Point(15, 255);
            lblTagline.Name      = "lblTagline";
            lblTagline.Size      = new Size(240, 45);
            lblTagline.TabIndex  = 1;
            lblTagline.Text      = "Robotics && Embedded\nComponents";
            lblTagline.TextAlign = ContentAlignment.MiddleCenter;
            // ── pnlRight ────────────────────────────────────────────────
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(lblSignIn);
            pnlRight.Controls.Add(lblUsername);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(lblError);
            pnlRight.Location = new Point(270, 0);
            pnlRight.Name     = "pnlRight";
            pnlRight.Size     = new Size(430, 480);
            pnlRight.TabIndex = 1;
            // ── lblSignIn ────────────────────────────────────────────────
            lblSignIn.AutoSize = false;
            lblSignIn.Font     = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblSignIn.ForeColor = Color.FromArgb(13, 71, 161);
            lblSignIn.Location = new Point(30, 50);
            lblSignIn.Name     = "lblSignIn";
            lblSignIn.Size     = new Size(180, 35);
            lblSignIn.TabIndex = 0;
            lblSignIn.Text     = "Sign In";
            // ── lblUsername ──────────────────────────────────────────────
            lblUsername.AutoSize  = true;
            lblUsername.Font      = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(66, 66, 66);
            lblUsername.Location  = new Point(30, 110);
            lblUsername.Name      = "lblUsername";
            lblUsername.Size      = new Size(60, 15);
            lblUsername.TabIndex  = 1;
            lblUsername.Text      = "Username";
            // ── txtUsername ──────────────────────────────────────────────
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font        = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location    = new Point(30, 130);
            txtUsername.Name        = "txtUsername";
            txtUsername.Size        = new Size(370, 28);
            txtUsername.TabIndex    = 2;
            // ── lblPassword ──────────────────────────────────────────────
            lblPassword.AutoSize  = true;
            lblPassword.Font      = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(66, 66, 66);
            lblPassword.Location  = new Point(30, 175);
            lblPassword.Name      = "lblPassword";
            lblPassword.Size      = new Size(57, 15);
            lblPassword.TabIndex  = 3;
            lblPassword.Text      = "Password";
            // ── txtPassword ──────────────────────────────────────────────
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font        = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location    = new Point(30, 195);
            txtPassword.Name        = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size        = new Size(370, 28);
            txtPassword.TabIndex    = 4;
            // ── btnLogin ─────────────────────────────────────────────────
            btnLogin.BackColor                 = Color.FromArgb(21, 101, 192);
            btnLogin.Cursor                    = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle                 = FlatStyle.Flat;
            btnLogin.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor                 = Color.White;
            btnLogin.Location                  = new Point(30, 250);
            btnLogin.Name                      = "btnLogin";
            btnLogin.Size                      = new Size(370, 45);
            btnLogin.TabIndex                  = 5;
            btnLogin.Text                      = "LOGIN";
            btnLogin.UseVisualStyleBackColor   = false;
            btnLogin.Click                    += btnLogin_Click;
            // ── lblError ─────────────────────────────────────────────────
            lblError.AutoSize  = true;
            lblError.Font      = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblError.ForeColor = Color.FromArgb(183, 28, 28);
            lblError.Location  = new Point(30, 310);
            lblError.Name      = "lblError";
            lblError.Size      = new Size(200, 15);
            lblError.TabIndex  = 6;
            lblError.Text      = "Invalid username or password.";
            lblError.Visible   = false;
            // ── frmLogin ─────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.White;
            ClientSize          = new Size(700, 480);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            Name            = "frmLogin";
            StartPosition   = FormStartPosition.CenterScreen;
            Text            = "Electronics Inventory System";
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel   pnlLeft;
        private System.Windows.Forms.Label   lblAppName;
        private System.Windows.Forms.Label   lblTagline;
        private System.Windows.Forms.Panel   pnlRight;
        private System.Windows.Forms.Label   lblSignIn;
        private System.Windows.Forms.Label   lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button  btnLogin;
        private System.Windows.Forms.Label   lblError;
        private EventHandler frmLogin_Load;
    }
}
