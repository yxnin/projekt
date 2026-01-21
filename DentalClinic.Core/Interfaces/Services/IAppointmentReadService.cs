using DentalClinic.Core.Models;

namespace DentalClinic.Core.Interfaces.Services;

public interface IAppointmentReadService
{
    Task<List<AppointmentListItem>> ListWithDetailsAsync(string? filterText, CancellationToken ct = default);
}
