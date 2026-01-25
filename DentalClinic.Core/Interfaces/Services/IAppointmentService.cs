using DentalClinic.Core.Entities;

namespace DentalClinic.Core.Interfaces.Services;

public interface IAppointmentService
{
    Task<Appointment> ScheduleAsync(int patientId, int dentistId, int serviceCatalogItemId, DateTime startUtc, CancellationToken ct = default);
    Task<Appointment?> GetAsync(int id, CancellationToken ct = default);
    Task<List<Appointment>> GetAllAsync(CancellationToken ct = default);

    // interpreter filtr tekstowy
    Task<List<Appointment>> GetFilteredAsync(string? filterText, CancellationToken ct = default);

    Task CancelAsync(int id, CancellationToken ct = default);

    // oznaczenie jako wykonana wizyta
    Task MarkDoneAsync(int id, CancellationToken ct = default);
}
