using DentalClinic.Core.Entities;

namespace DentalClinic.WinForms;

public partial class PatientEditForm : Form
{
    public Patient Result { get; private set; }

    public PatientEditForm()
    {
        InitializeComponent();
        Result = new Patient();
        LoadToControls(Result);
    }

    public PatientEditForm(Patient existing) : this()
    {
        Result = new Patient
        {
            Id = existing.Id,
            FirstName = existing.FirstName,
            LastName = existing.LastName,
            Phone = existing.Phone,
            BirthDate = existing.BirthDate
        };
        LoadToControls(Result);
    }

    private void LoadToControls(Patient p)
    {
        tbFirstName.Text = p.FirstName;
        tbLastName.Text = p.LastName;
        tbPhone.Text = p.Phone;

        if (p.BirthDate.HasValue)
        {
            dtBirth.Checked = true;
            dtBirth.Value = p.BirthDate.Value.ToDateTime(TimeOnly.MinValue);
        }
        else
        {
            dtBirth.Checked = false;
            dtBirth.Value = DateTime.Today;
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        Result.FirstName = tbFirstName.Text.Trim();
        Result.LastName = tbLastName.Text.Trim();
        Result.Phone = tbPhone.Text.Trim();
        Result.BirthDate = dtBirth.Checked ? DateOnly.FromDateTime(dtBirth.Value.Date) : null;

        if (string.IsNullOrWhiteSpace(Result.FirstName) || string.IsNullOrWhiteSpace(Result.LastName))
        {
            MessageBox.Show("First name and last name are required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
        }
    }
}
