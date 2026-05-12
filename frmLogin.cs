namespace ElectronicsInventory;

// ============================================================
// frmLogin.cs  –  Login Screen
// ============================================================
// The first window users see when they launch the application.
// Requires a valid username and password before granting access
// to the main dashboard and all other features.
//
// CURRENT CREDENTIALS (hardcoded for demo purposes):
//   Username: admin
//   Password: admin123
//
// HOW LOGIN WORKS:
//   1. User types username and password and clicks Login.
//   2. The app compares the input against the hardcoded values.
//   3. If correct: open the main dashboard (frmMain), hide this window.
//   4. If wrong:   show an error label, clear the password field.
//
// NOTE FOR GROUPMATES:
//   In a production system, passwords should NEVER be hardcoded.
//   They should be stored as hashed values in the database and
//   compared using a secure hashing algorithm (e.g. bcrypt).
//   This demo version is simplified for learning purposes.
// ============================================================

public partial class frmLogin : Form
{
    public frmLogin()
    {
        InitializeComponent(); // Auto-generated: sets up all UI controls.
    }

    // Fires when the Login button is clicked.
    private void btnLogin_Click(object sender, EventArgs e)
    {
        string user = txtUsername.Text.Trim(); // Get username (remove extra spaces).
        string pass = txtPassword.Text;        // Get password (keep spaces as-is).

        // Check credentials against the hardcoded admin account.
        if (user == "admin" && pass == "admin123")
        {
            lblError.Visible = false; // Hide any previous error message.

            // Open the main dashboard window.
            frmMain menu = new frmMain();
            menu.Show();

            // Hide the login window (don't close it — we need it if the user logs out).
            this.Hide();
        }
        else
        {
            // Show the error label and clear the password so the user can try again.
            lblError.Visible = true;
            txtPassword.Clear();
            txtPassword.Focus(); // Move cursor to the password field.
        }
    }
}
