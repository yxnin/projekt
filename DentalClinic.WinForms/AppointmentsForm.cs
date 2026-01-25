using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Models;
using DentalClinic.WinForms.Notifications;
using DentalClinic.WinForms.Reports;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.WinForms;

public partial class AppointmentsForm : Form
{
    private readonly IAppointmentReadService? _read;
    private readonly IClinicMediator? _mediator;
    private readonly IAppointmentService? _appointments;
    private readonly IEnumerable<IAppointmentReportFactory>? _reportFactories;

    public AppointmentsForm()
    {
        InitializeComponent();
    }

    public AppointmentsForm(
        IAppointmentReadService read,
        IClinicMediator mediator,
        IAppointmentService appointments,
        IEnumerable<IAppointmentReportFactory> reportFactories) : this()
    {
        _read = read;
        _mediator = mediator;
        _appointments = appointments;
        _reportFactories = reportFactories;
    }

    private async void AppointmentsForm_Shown(object sender, EventArgs e)
    {
        await ReloadAsync();
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await ReloadAsync();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (_mediator is null) return;

        using var dlg = Program.ServiceProvider.GetRequiredService<AppointmentCreateForm>();
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            var req = dlg.Request!;
            await _mediator.ScheduleAppointmentAsync(req);
            await ReloadAsync();

            var notifier = new MessageBoxNotificationCreator(this);
            notifier.Notify(
                "Appointment scheduled",
                $"PatientId={req.PatientId}, DentistId={req.DentistId}, ServiceId={req.ServiceCatalogItemId}, StartUtc={req.StartUtc:O}"
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnCancelAppointment_Click(object sender, EventArgs e)
    {
        if (_appointments is null) return;

        var selected = GetSelected();
        if (selected is null) return;

        if (MessageBox.Show($"Cancel appointment #{selected.AppointmentId}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            await _appointments.CancelAsync(selected.AppointmentId);
            await ReloadAsync();

            var notifier = new MessageBoxNotificationCreator(this);
            notifier.Notify("Appointment cancelled", $"AppointmentId={selected.AppointmentId}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnExport_Click(object sender, EventArgs e)
    {
        if (_reportFactories is null) return;

        // wybór formatu: Yes = JSON, No = TXT
        var choice = MessageBox.Show(
            "Export format:\nYes = JSON\nNo = TXT",
            "Export",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

        if (choice == DialogResult.Cancel) return;

        var format = (choice == DialogResult.Yes) ? "JSON" : "TXT";
        var factory = _reportFactories.FirstOrDefault(f => f.Format == format);

        if (factory is null)
        {
            MessageBox.Show("Report factory not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var filter = tbFilter.Text?.Trim();

        try
        {
            var generator = factory.CreateGenerator();
            var exporter = factory.CreateExporter();

            var data = await generator.GenerateAsync(filter);

            using var sfd = new SaveFileDialog
            {
                Filter = factory.Description,
                DefaultExt = factory.DefaultExtension.TrimStart('.'),
                FileName = $"appointments_{DateTime.Now:yyyyMMdd_HHmm}{factory.DefaultExtension}"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            exporter.Export(data, sfd.FileName);

            MessageBox.Show("Export completed.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private AppointmentListItem? GetSelected()
    {
        if (gridAppointments.CurrentRow?.DataBoundItem is AppointmentListItem a)
            return a;

        MessageBox.Show("Select an appointment first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
    }

    private async Task ReloadAsync()
    {
        if (_read is null) return;

        var filter = tbFilter.Text?.Trim();
        var data = await _read.ListWithDetailsAsync(filter);
        gridAppointments.DataSource = data;
    }
}
