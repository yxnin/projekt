namespace DentalClinic.Core.Models;

public sealed record AppointmentListItem(
    int AppointmentId,
    DateTime StartUtc,
    string Status,

    int PatientId,
    string PatientFullName,

    int DentistId,
    string DentistFullName,

    int ServiceCatalogItemId,
    string ServiceName,
    decimal ServicePrice,
    int DurationMinutes
);
