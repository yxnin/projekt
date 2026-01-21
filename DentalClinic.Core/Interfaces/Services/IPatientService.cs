using DentalClinic.Core.Entities;

namespace DentalClinic.Core.Interfaces.Services;

public interface IPatientService
{
    Task<Patient> CreateAsync(Patient patient, CancellationToken ct = default);
    Task<Patient?> GetAsync(int id, CancellationToken ct = default);
    Task<List<Patient>> GetAllAsync(CancellationToken ct = default);
    Task UpdateAsync(Patient patient, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}
