using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Models;
using DentalClinic.WinForms.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.WinForms;

public partial class UserAppointmentsForm : Form
{
    private readonly IAppointmentReadService? _read;
    private readonly IClinicMediator? _mediator;
    private readonly IAppointmentService? _appointments;
    private readonly AppSession? _session;

    public UserAppointmentsForm()
    {
        InitializeComponent();
    }

    public UserAppointmentsForm(
        IAppointmentReadService read,
        IClinicMediator mediator,
        IAppointmentService appointments,
        AppSession session) : this()
    {
        _read = read;
        _mediator = mediator;
        _appointments = appointments;
        _session = session;
    }

    private async void UserAppointmentsForm_Shown(object sender, EventArgs e)
    {
        var user = _session?.CurrentUser;
        if (user is null)
        {
            MessageBox.Show("Najpierw musisz się zalogować.", "Informacja",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            return;
        }

        if (user.PatientId is null)
        {
            MessageBox.Show("To konto nie jest powiązane z kartą pacjenta. Skontaktuj się z administratorem.", "Informacja",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAdd.Enabled = false;
            btnCancel.Enabled = false;
        }

        lblInfo.Text = $"Zalogowano jako: {user.Email}";
        await ReloadAsync();
    }

    private async void btnRefresh_Click(object sender, EventArgs e) => await ReloadAsync();

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        var user = _session?.CurrentUser;
        if (_mediator is null || user?.PatientId is null) return;

        using var dlg = Program.ServiceProvider.GetRequiredService<UserAppointmentCreateForm>();
        dlg.PatientId = user.PatientId.Value;

        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            var req = dlg.Request!;
            await _mediator.ScheduleAppointmentAsync(req);
            await ReloadAsync();

            new MessageBoxNotificationCreator(this)
                .Notify("Wizyta umówiona",
                    $"Termin (UTC): {req.StartUtc:O}, DentystaId={req.DentistId}, UsługaId={req.ServiceCatalogItemId}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnCancel_Click(object sender, EventArgs e)
    {
        var user = _session?.CurrentUser;
        if (_appointments is null || user?.PatientId is null) return;

        var selected = GetSelected();
        if (selected is null) return;

        if (MessageBox.Show($"Anulować wizytę (ID={selected.AppointmentId})?", "Potwierdź",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            await _appointments.CancelAsync(selected.AppointmentId);
            await ReloadAsync();

            new MessageBoxNotificationCreator(this)
                .Notify("Wizyta anulowana", $"ID wizyty: {selected.AppointmentId}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        var user = _session?.CurrentUser;
        var patientId = user?.PatientId;

        if (_read is null || patientId is null) return;

        var data = await _read.ListWithDetailsAsync($"patientId={patientId.Value}");
        gridAppointments.DataSource = data;

        ApplyPolishColumnHeaders();
    }

    private void ApplyPolishColumnHeaders()
    {
        if (gridAppointments.Columns.Count == 0) return;

        // Nagłówki po polsku (DTO AppointmentListItem)
        if (gridAppointments.Columns.Contains("StartUtc"))
            gridAppointments.Columns["StartUtc"].HeaderText = "Termin (UTC)";

        if (gridAppointments.Columns.Contains("Status"))
            gridAppointments.Columns["Status"].HeaderText = "Status";

        if (gridAppointments.Columns.Contains("DentistFullName"))
            gridAppointments.Columns["DentistFullName"].HeaderText = "Dentysta";

        if (gridAppointments.Columns.Contains("ServiceName"))
            gridAppointments.Columns["ServiceName"].HeaderText = "Usługa";

        if (gridAppointments.Columns.Contains("ServicePrice"))
            gridAppointments.Columns["ServicePrice"].HeaderText = "Cena";

        if (gridAppointments.Columns.Contains("DurationMinutes"))
            gridAppointments.Columns["DurationMinutes"].HeaderText = "Czas (min)";

        // Ukryj dane techniczne / zbędne dla pacjenta
        if (gridAppointments.Columns.Contains("AppointmentId"))
        {
            gridAppointments.Columns["AppointmentId"].HeaderText = "ID wizyty";
            // jeśli chcesz ukryć ID całkiem:
            // gridAppointments.Columns["AppointmentId"].Visible = false;
        }

        if (gridAppointments.Columns.Contains("PatientId"))
            gridAppointments.Columns["PatientId"].Visible = false;

        if (gridAppointments.Columns.Contains("PatientFullName"))
            gridAppointments.Columns["PatientFullName"].Visible = false;

        if (gridAppointments.Columns.Contains("DentistId"))
            gridAppointments.Columns["DentistId"].Visible = false;

        if (gridAppointments.Columns.Contains("ServiceCatalogItemId"))
            gridAppointments.Columns["ServiceCatalogItemId"].Visible = false;
    }
}
