using System.ComponentModel;
using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.WinForms;

public partial class UserAppointmentCreateForm : Form
{
    private readonly IDentistService? _dentists;
    private readonly IServiceCatalogService? _services;

    // blokada serializacji w designerze
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int PatientId { get; set; }

    public ScheduleAppointmentRequest? Request { get; private set; }

    public UserAppointmentCreateForm()
    {
        InitializeComponent();
    }

    public UserAppointmentCreateForm(IDentistService dentists, IServiceCatalogService services) : this()
    {
        _dentists = dentists;
        _services = services;
    }

    protected override async void OnShown(EventArgs e)
    {
        base.OnShown(e);
        if (_dentists is null || _services is null) return;

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
        if (PatientId <= 0)
        {
            MessageBox.Show("Missing PatientId.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.None;
            return;
        }

        if (cbDentist.SelectedItem is not Dentist d || cbService.SelectedItem is not ServiceCatalogItem s)
        {
            MessageBox.Show("Select dentist and service.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        var local = dtStart.Value;
        var utc = DateTime.SpecifyKind(local, DateTimeKind.Local).ToUniversalTime();

        Request = new ScheduleAppointmentRequest(PatientId, d.Id, s.Id, utc);

        DialogResult = DialogResult.OK;
        Close();
    }
}
