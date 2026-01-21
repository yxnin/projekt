using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.Core.Patterns;

public class ClinicMediator : IClinicMediator
{
    private readonly IAppointmentService _appointments;

    public ClinicMediator(IAppointmentService appointments)
    {
        _appointments = appointments;
    }

    public Task<Appointment> ScheduleAppointmentAsync(ScheduleAppointmentRequest request, CancellationToken ct = default)
    {
        return _appointments.ScheduleAsync(
            request.PatientId,
            request.DentistId,
            request.ServiceCatalogItemId,
            request.StartUtc,
            ct);
    }
}
