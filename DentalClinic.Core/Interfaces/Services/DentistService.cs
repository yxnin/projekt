using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.Core.Services;

public class DentistService : IDentistService
{
    private readonly IRepository<Dentist> _repo;

    public DentistService(IRepository<Dentist> repo) => _repo = repo;

    public async Task<Dentist> CreateAsync(Dentist dentist, CancellationToken ct = default)
    {
        Validate(dentist);
        await _repo.AddAsync(dentist, ct);
        await _repo.SaveChangesAsync(ct);
        return dentist;
    }

    public Task<Dentist?> GetAsync(int id, CancellationToken ct = default) =>
        _repo.GetByIdAsync(id, ct);

    public Task<List<Dentist>> GetAllAsync(CancellationToken ct = default) =>
        _repo.ListAsync(ct);

    public async Task UpdateAsync(Dentist dentist, CancellationToken ct = default)
    {
        if (dentist.Id <= 0) throw new ArgumentException("Dentist Id is required.");
        Validate(dentist);
        _repo.Update(dentist);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var existing = await _repo.GetByIdAsync(id, ct);
        if (existing is null) return;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
    }

    private static void Validate(Dentist d)
    {
        if (string.IsNullOrWhiteSpace(d.FirstName)) throw new ArgumentException("First name is required.");
        if (string.IsNullOrWhiteSpace(d.LastName)) throw new ArgumentException("Last name is required.");
        if (string.IsNullOrWhiteSpace(d.Specialization)) throw new ArgumentException("Specialization is required.");
    }
}
