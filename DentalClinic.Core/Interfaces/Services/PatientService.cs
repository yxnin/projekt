using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.Core.Services;

public class PatientService : IPatientService
{
    private readonly IRepository<Patient> _repo;

    public PatientService(IRepository<Patient> repo) => _repo = repo;

    public async Task<Patient> CreateAsync(Patient patient, CancellationToken ct = default)
    {
        Validate(patient);
        await _repo.AddAsync(patient, ct);
        await _repo.SaveChangesAsync(ct);
        return patient;
    }

    public Task<Patient?> GetAsync(int id, CancellationToken ct = default) =>
        _repo.GetByIdAsync(id, ct);

    public Task<List<Patient>> GetAllAsync(CancellationToken ct = default) =>
        _repo.ListAsync(ct);

    public async Task UpdateAsync(Patient patient, CancellationToken ct = default)
    {
        if (patient.Id <= 0) throw new ArgumentException("Patient Id is required.");
        Validate(patient);
        _repo.Update(patient);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var existing = await _repo.GetByIdAsync(id, ct);
        if (existing is null) return;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
    }

    private static void Validate(Patient p)
    {
        if (string.IsNullOrWhiteSpace(p.FirstName)) throw new ArgumentException("First name is required.");
        if (string.IsNullOrWhiteSpace(p.LastName)) throw new ArgumentException("Last name is required.");
        if (!string.IsNullOrWhiteSpace(p.Phone))
        {
            var digits = new string(p.Phone.Where(char.IsDigit).ToArray());
            if (digits.Length < 7) throw new ArgumentException("Phone number is too short.");
        }
    }
}
