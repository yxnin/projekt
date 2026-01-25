using DentalClinic.Core.Entities;

namespace DentalClinic.WinForms;

public partial class RegisterPatientForm : Form
{
    public Patient Result { get; private set; } = new Patient();

    public RegisterPatientForm()
    {
        InitializeComponent();
        dtBirth.Checked = false;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        Result.FirstName = tbFirstName.Text.Trim();
        Result.LastName = tbLastName.Text.Trim();
        Result.Phone = tbPhone.Text.Trim();
        Result.BirthDate = dtBirth.Checked ? DateOnly.FromDateTime(dtBirth.Value.Date) : null;

        if (string.IsNullOrWhiteSpace(Result.FirstName) || string.IsNullOrWhiteSpace(Result.LastName))
        {
            MessageBox.Show("Imię i nazwisko jest wymagane.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}
