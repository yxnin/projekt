using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Models;

namespace DentalClinic.WinForms.Reports;

public sealed class AppointmentListGenerator : IReportGenerator<List<AppointmentListItem>>
{
    private readonly IAppointmentReadService _read;

    public AppointmentListGenerator(IAppointmentReadService read)
    {
        _read = read;
    }

    public Task<List<AppointmentListItem>> GenerateAsync(string? filterText, CancellationToken ct = default)
        => _read.ListWithDetailsAsync(filterText, ct);
}
