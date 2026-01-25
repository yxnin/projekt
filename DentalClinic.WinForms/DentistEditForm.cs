using DentalClinic.Core.Entities;

namespace DentalClinic.WinForms;

public partial class DentistEditForm : Form
{
    public Dentist Result { get; private set; }

    public DentistEditForm()
    {
        InitializeComponent();
        Result = new Dentist();
        LoadToControls(Result);
    }

    public DentistEditForm(Dentist existing) : this()
    {
        Result = new Dentist
        {
            Id = existing.Id,
            FirstName = existing.FirstName,
            LastName = existing.LastName,
            Phone = existing.Phone,
            Specialization = existing.Specialization
        };
        LoadToControls(Result);
    }

    private void LoadToControls(Dentist d)
    {
        tbFirstName.Text = d.FirstName;
        tbLastName.Text = d.LastName;
        tbPhone.Text = d.Phone;
        tbSpecialization.Text = d.Specialization;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        Result.FirstName = tbFirstName.Text.Trim();
        Result.LastName = tbLastName.Text.Trim();
        Result.Phone = tbPhone.Text.Trim();
        Result.Specialization = tbSpecialization.Text.Trim();

        if (string.IsNullOrWhiteSpace(Result.FirstName) || string.IsNullOrWhiteSpace(Result.LastName))
        {
            MessageBox.Show("Imię i nazwisko jest wymagane.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        if (string.IsNullOrWhiteSpace(Result.Specialization))
        {
            MessageBox.Show("Wymagane jest podanie specjalizacji.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void lblFirst_Click(object sender, EventArgs e)
    {

    }
}
