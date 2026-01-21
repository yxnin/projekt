using DentalClinic.Core.Entities;

namespace DentalClinic.Core.Interfaces.Services;

public interface IDentistService
{
    Task<Dentist> CreateAsync(Dentist dentist, CancellationToken ct = default);
    Task<Dentist?> GetAsync(int id, CancellationToken ct = default);
    Task<List<Dentist>> GetAllAsync(CancellationToken ct = default);
    Task UpdateAsync(Dentist dentist, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}