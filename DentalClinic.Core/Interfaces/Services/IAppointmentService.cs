using DentalClinic.Core.Entities;

namespace DentalClinic.Core.Interfaces.Services;

public interface IAppointmentService
{
    Task<Appointment> ScheduleAsync(Appointment appointment, CancellationToken ct = default);
    Task<Appointment?> GetAsync(int id, CancellationToken ct = default);
    Task<List<Appointment>> GetAllAsync(CancellationToken ct = default);
    Task CancelAsync(int id, CancellationToken ct = default);
}