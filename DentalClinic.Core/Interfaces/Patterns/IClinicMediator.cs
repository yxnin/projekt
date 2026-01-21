using DentalClinic.Core.Entities;

namespace DentalClinic.Core.Interfaces.Patterns;

public interface IClinicMediator
{
    Task<Appointment> ScheduleAppointmentAsync(ScheduleAppointmentRequest request, CancellationToken ct = default);
}

public sealed record ScheduleAppointmentRequest(
    int PatientId,
    int DentistId,
    int ServiceCatalogItemId,
    DateTime StartUtc
);
