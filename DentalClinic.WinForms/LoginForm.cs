using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.WinForms;

public partial class LoginForm : Form
{
    private readonly IAuthService? _auth;
    private readonly AppSession? _session;

    public LoginForm()
    {
        InitializeComponent();
        tbEmail.Text = "";
        tbPassword.Text = "";
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
                MessageBox.Show("Błędne dane logowania", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _session.SignIn(user);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        using var reg = Program.ServiceProvider.GetRequiredService<RegisterForm>();
        if (reg.ShowDialog(this) == DialogResult.OK)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }


}
