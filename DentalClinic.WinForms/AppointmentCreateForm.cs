using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.WinForms;

public partial class AppointmentCreateForm : Form
{
    private readonly IPatientService? _patients;
    private readonly IDentistService? _dentists;
    private readonly IServiceCatalogService? _services;

    public ScheduleAppointmentRequest? Request { get; private set; }

    public AppointmentCreateForm()
    {
        InitializeComponent();
    }

    public AppointmentCreateForm(IPatientService patients, IDentistService dentists, IServiceCatalogService services) : this()
    {
        _patients = patients;
        _dentists = dentists;
        _services = services;
    }

    protected override async void OnShown(EventArgs e)
    {
        base.OnShown(e);
        if (_patients is null || _dentists is null || _services is null) return;

        var p = await _patients.GetAllAsync();
        cbPatient.DataSource = p;
        cbPatient.DisplayMember = nameof(Patient.LastName);
        cbPatient.ValueMember = nameof(Patient.Id);

        var d = await _dentists.GetAllAsync();
        cbDentist.DataSource = d;
        cbDentist.DisplayMember = nameof(Dentist.LastName);
        cbDentist.ValueMember = nameof(Dentist.Id);

        var s = await _services.GetAllAsync();
        cbService.DataSource = s;
        cbService.DisplayMember = nameof(ServiceCatalogItem.Name);
        cbService.ValueMember = nameof(ServiceCatalogItem.Id);

        dtStart.Value = DateTime.Now.AddHours(1);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (cbPatient.SelectedItem is not Patient p ||
            cbDentist.SelectedItem is not Dentist d ||
            cbService.SelectedItem is not ServiceCatalogItem s)
        {
            MessageBox.Show("Select patient, dentist and service.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        var local = dtStart.Value;
        var utc = DateTime.SpecifyKind(local, DateTimeKind.Local).ToUniversalTime();

        Request = new ScheduleAppointmentRequest(p.Id, d.Id, s.Id, utc);

        DialogResult = DialogResult.OK;
        Close();
    }
}
