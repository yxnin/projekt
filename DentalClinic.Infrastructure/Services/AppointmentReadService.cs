using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Models;
using DentalClinic.Core.Patterns;
using DentalClinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Infrastructure.Services;

public class AppointmentReadService : IAppointmentReadService
{
    private readonly DentalClinicDbContext _db;

    public AppointmentReadService(DentalClinicDbContext db)
    {
        _db = db;
    }

    public async Task<List<AppointmentListItem>> ListWithDetailsAsync(string? filterText, CancellationToken ct = default)
    {
        var filter = AppointmentFilterParser.Parse(filterText).ToExpression();

        var query = _db.Appointments
            .AsNoTracking()
            .Where(filter)
            .Include(a => a.Patient)
            .Include(a => a.Dentist)
            .Include(a => a.Service)
            .OrderBy(a => a.StartUtc);

        return await query
            .Select(a => new AppointmentListItem(
                a.Id,
                a.StartUtc,
                a.Status,

                a.PatientId,
                (a.Patient != null ? (a.Patient.FirstName + " " + a.Patient.LastName) : ""),

                a.DentistId,
                (a.Dentist != null ? (a.Dentist.FirstName + " " + a.Dentist.LastName) : ""),

                a.ServiceCatalogItemId,
                (a.Service != null ? a.Service.Name : ""),
                (a.Service != null ? a.Service.Price : 0m),
                (a.Service != null ? a.Service.DurationMinutes : 0)
            ))
            .ToListAsync(ct);
    }
}
