using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Models;
using Microsoft.Extensions.DependencyInjection;


namespace DentalClinic.WinForms;

public partial class AppointmentsForm : Form
{
    private readonly IAppointmentReadService? _read;
    private readonly IClinicMediator? _mediator;
    private readonly IAppointmentService? _appointments;

    public AppointmentsForm()
    {
        InitializeComponent();
    }

    public AppointmentsForm(IAppointmentReadService read, IClinicMediator mediator, IAppointmentService appointments) : this()
    {
        _read = read;
        _mediator = mediator;
        _appointments = appointments;
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

        using var dlg = Program.ServiceProvider.GetRequiredService<AppointmentCreateForm>(); // patrz dopisek niżej
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _mediator.ScheduleAppointmentAsync(dlg.Request!);
            await ReloadAsync();
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
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
