using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.WinForms;

public partial class LoginForm : Form
{
    private readonly IAuthService? _auth;
    private readonly AppSession? _session;

    public LoginForm()
    {
        InitializeComponent();

        // Pod seed:
        tbEmail.Text = "admin@clinic.local";
        tbPassword.Text = "Admin123!";
    }

    public LoginForm(IAuthService auth, AppSession session) : this()
    {
        _auth = auth;
        _session = session;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        if (_auth is null || _session is null) return;

        var email = tbEmail.Text.Trim();
        var pass = tbPassword.Text;

        try
        {
            var user = await _auth.LoginAsync(email, pass);
            if (user is null)
            {
                MessageBox.Show("Bad credentials.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _session.SignIn(user);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnRegister_Click(object sender, EventArgs e)
    {
        if (_auth is null || _session is null) return;

        var email = tbEmail.Text.Trim();
        var pass = tbPassword.Text;

        try
        {
            var user = await _auth.RegisterAsync(email, pass, UserRoles.User);
            _session.SignIn(user);

            MessageBox.Show("Registered and logged in.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
