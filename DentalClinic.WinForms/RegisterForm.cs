using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.WinForms;

public partial class RegisterForm : Form
{
    private readonly IAuthService? _auth;
    private readonly IPatientService? _patients;
    private readonly AppSession? _session;

    public RegisterForm()
    {
        InitializeComponent();
        dtBirth.Checked = false;
    }

    public RegisterForm(IAuthService auth, IPatientService patients, AppSession session) : this()
    {
        _auth = auth;
        _patients = patients;
        _session = session;
    }

    private async void btnRegister_Click(object sender, EventArgs e)
    {
        if (_auth is null || _patients is null || _session is null) return;

        var email = tbEmail.Text.Trim();
        var pass = tbPassword.Text;
        var pass2 = tbPassword2.Text;

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
        {
            MessageBox.Show("Podaj poprawny email.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tbEmail.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(pass) || pass.Length < 6)
        {
            MessageBox.Show("Hasło musi mieć min. 6 znaków.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tbPassword.Focus();
            return;
        }

        if (pass != pass2)
        {
            MessageBox.Show("Hasła nie są identyczne.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tbPassword2.Focus();
            return;
        }

        var patient = new Patient
        {
            FirstName = tbFirstName.Text.Trim(),
            LastName = tbLastName.Text.Trim(),
            Phone = tbPhone.Text.Trim(),
            BirthDate = dtBirth.Checked ? DateOnly.FromDateTime(dtBirth.Value.Date) : null
        };

        if (string.IsNullOrWhiteSpace(patient.FirstName) || string.IsNullOrWhiteSpace(patient.LastName))
        {
            MessageBox.Show("Podaj imię i nazwisko.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // 1) pacjent
            var createdPatient = await _patients.CreateAsync(patient);

            // 2) user
            var user = await _auth.RegisterAsync(email, pass, UserRoles.User);

            // 3) link user->patient
            await _auth.LinkPatientAsync(user.Id, createdPatient.Id);
            user.PatientId = createdPatient.Id;

            // 4) sign in
            _session.SignIn(user);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Register error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
