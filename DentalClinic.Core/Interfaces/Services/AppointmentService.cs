using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Patterns;

namespace DentalClinic.Core.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IRepository<Appointment> _appointments;
    private readonly IRepository<Patient> _patients;
    private readonly IRepository<Dentist> _dentists;
    private readonly IRepository<ServiceCatalogItem> _services;

    public AppointmentService(
        IRepository<Appointment> appointments,
        IRepository<Patient> patients,
        IRepository<Dentist> dentists,
        IRepository<ServiceCatalogItem> services)
    {
        _appointments = appointments;
        _patients = patients;
        _dentists = dentists;
        _services = services;
    }

    public async Task<Appointment> ScheduleAsync(int patientId, int dentistId, int serviceCatalogItemId, DateTime startUtc, CancellationToken ct = default)
    {
        if (patientId <= 0) throw new ArgumentException("PatientId is required.");
        if (dentistId <= 0) throw new ArgumentException("DentistId is required.");
        if (serviceCatalogItemId <= 0) throw new ArgumentException("ServiceCatalogItemId is required.");

        var patient = await _patients.GetByIdAsync(patientId, ct) ?? throw new ArgumentException("Patient not found.");
        var dentist = await _dentists.GetByIdAsync(dentistId, ct) ?? throw new ArgumentException("Dentist not found.");
        var service = await _services.GetByIdAsync(serviceCatalogItemId, ct) ?? throw new ArgumentException("Service not found.");

        if (service.DurationMinutes <= 0) throw new ArgumentException("Service duration is invalid.");

        if (startUtc.Kind != DateTimeKind.Utc)
            startUtc = DateTime.SpecifyKind(startUtc, DateTimeKind.Utc);

        var endUtc = startUtc.AddMinutes(service.DurationMinutes);

        var existing = await _appointments.FindAsync(a =>
            a.DentistId == dentistId &&
            a.Status == AppointmentStatus.Scheduled, ct);

        foreach (var a in existing)
        {
            var otherService = await _services.GetByIdAsync(a.ServiceCatalogItemId, ct);
            var otherDuration = otherService?.DurationMinutes > 0 ? otherService.DurationMinutes : 30;

            var aStart = a.StartUtc.Kind == DateTimeKind.Utc ? a.StartUtc : DateTime.SpecifyKind(a.StartUtc, DateTimeKind.Utc);
            var aEnd = aStart.AddMinutes(otherDuration);

            var overlap = startUtc < aEnd && endUtc > aStart;
            if (overlap)
                throw new ArgumentException("Dentist already has an appointment at this time.");
        }

        var appointment = new Appointment
        {
            PatientId = patient.Id,
            DentistId = dentist.Id,
            ServiceCatalogItemId = service.Id,
            StartUtc = startUtc,
            Status = AppointmentStatus.Scheduled
        };

        await _appointments.AddAsync(appointment, ct);
        await _appointments.SaveChangesAsync(ct);

        return appointment;
    }

    public Task<Appointment?> GetAsync(int id, CancellationToken ct = default) =>
        _appointments.GetByIdAsync(id, ct);

    public Task<List<Appointment>> GetAllAsync(CancellationToken ct = default) =>
        _appointments.ListAsync(ct);

    public Task<List<Appointment>> GetFilteredAsync(string? filterText, CancellationToken ct = default)
    {
        var filter = AppointmentFilterParser.Parse(filterText);
        return _appointments.FindAsync(filter.ToExpression(), ct);
    }

    public async Task CancelAsync(int id, CancellationToken ct = default)
    {
        var appt = await _appointments.GetByIdAsync(id, ct);
        if (appt is null) return;

        if (appt.Status == AppointmentStatus.Done)
            throw new ArgumentException("Cannot cancel a completed appointment.");

        appt.Status = AppointmentStatus.Cancelled;
        _appointments.Update(appt);
        await _appointments.SaveChangesAsync(ct);
    }

    public async Task MarkDoneAsync(int id, CancellationToken ct = default)
    {
        var appt = await _appointments.GetByIdAsync(id, ct);
        if (appt is null) return;

        if (appt.Status == AppointmentStatus.Cancelled)
            throw new ArgumentException("Cannot complete a cancelled appointment.");

        appt.Status = AppointmentStatus.Done;
        _appointments.Update(appt);
        await _appointments.SaveChangesAsync(ct);
    }
}
