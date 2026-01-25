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
        // placeholder 
        tbFilter.PlaceholderText = "Filtr (np. status=Scheduled AND dentistId=1 AND date>=2026-01-01)";

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
                "Wizyta umówiona",
                $"PacjentId={req.PatientId}, DentystaId={req.DentistId}, UsługaId={req.ServiceCatalogItemId}, Termin(UTC)={req.StartUtc:O}"
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnCancelAppointment_Click(object sender, EventArgs e)
    {
        if (_appointments is null) return;

        var selected = GetSelected();
        if (selected is null) return;

        if (MessageBox.Show($"Anulować wizytę (ID={selected.AppointmentId})?", "Potwierdź",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            await _appointments.CancelAsync(selected.AppointmentId);
            await ReloadAsync();

            var notifier = new MessageBoxNotificationCreator(this);
            notifier.Notify("Wizyta anulowana", $"ID wizyty: {selected.AppointmentId}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnExport_Click(object sender, EventArgs e)
    {
        if (_reportFactories is null) return;

        var choice = MessageBox.Show(
            "Format eksportu:\nTak = JSON\nNie = TXT",
            "Eksport",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

        if (choice == DialogResult.Cancel) return;

        var format = (choice == DialogResult.Yes) ? "JSON" : "TXT";
        var factory = _reportFactories.FirstOrDefault(f => f.Format == format);

        if (factory is null)
        {
            MessageBox.Show("Nie znaleziono fabryki raportu.", "Błąd",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                FileName = $"wizyty_{DateTime.Now:yyyyMMdd_HHmm}{factory.DefaultExtension}"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            exporter.Export(data, sfd.FileName);

            MessageBox.Show("Eksport zakończony.", "Eksport",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd eksportu",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private AppointmentListItem? GetSelected()
    {
        if (gridAppointments.CurrentRow?.DataBoundItem is AppointmentListItem a)
            return a;

        MessageBox.Show("Najpierw wybierz wizytę z listy.", "Informacja",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
    }

    private async Task ReloadAsync()
    {
        if (_read is null) return;

        var filter = tbFilter.Text?.Trim();
        var data = await _read.ListWithDetailsAsync(filter);
        gridAppointments.DataSource = data;

        ApplyPolishColumnHeaders();
    }

    private void ApplyPolishColumnHeaders()
    {
        if (gridAppointments.Columns.Count == 0) return;

        if (gridAppointments.Columns.Contains("AppointmentId"))
            gridAppointments.Columns["AppointmentId"].HeaderText = "ID wizyty";

        if (gridAppointments.Columns.Contains("StartUtc"))
            gridAppointments.Columns["StartUtc"].HeaderText = "Termin (UTC)";

        if (gridAppointments.Columns.Contains("Status"))
            gridAppointments.Columns["Status"].HeaderText = "Status";

        if (gridAppointments.Columns.Contains("PatientFullName"))
            gridAppointments.Columns["PatientFullName"].HeaderText = "Pacjent";

        if (gridAppointments.Columns.Contains("DentistFullName"))
            gridAppointments.Columns["DentistFullName"].HeaderText = "Dentysta";

        if (gridAppointments.Columns.Contains("ServiceName"))
            gridAppointments.Columns["ServiceName"].HeaderText = "Usługa";

        if (gridAppointments.Columns.Contains("ServicePrice"))
            gridAppointments.Columns["ServicePrice"].HeaderText = "Cena";

        if (gridAppointments.Columns.Contains("DurationMinutes"))
            gridAppointments.Columns["DurationMinutes"].HeaderText = "Czas (min)";

        // ukrycie
        if (gridAppointments.Columns.Contains("PatientId"))
            gridAppointments.Columns["PatientId"].Visible = false;

        if (gridAppointments.Columns.Contains("DentistId"))
            gridAppointments.Columns["DentistId"].Visible = false;

        if (gridAppointments.Columns.Contains("ServiceCatalogItemId"))
            gridAppointments.Columns["ServiceCatalogItemId"].Visible = false;
    }
}
