using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.Core.Services;

public class ServiceCatalogService : IServiceCatalogService
{
    private readonly IRepository<ServiceCatalogItem> _repo;

    public ServiceCatalogService(IRepository<ServiceCatalogItem> repo) => _repo = repo;

    public async Task<ServiceCatalogItem> CreateAsync(ServiceCatalogItem item, CancellationToken ct = default)
    {
        Validate(item);
        await _repo.AddAsync(item, ct);
        await _repo.SaveChangesAsync(ct);
        return item;
    }

    public Task<ServiceCatalogItem?> GetAsync(int id, CancellationToken ct = default) =>
        _repo.GetByIdAsync(id, ct);

    public Task<List<ServiceCatalogItem>> GetAllAsync(CancellationToken ct = default) =>
        _repo.ListAsync(ct);

    public async Task UpdateAsync(ServiceCatalogItem item, CancellationToken ct = default)
    {
        if (item.Id <= 0) throw new ArgumentException("Service Id is required.");
        Validate(item);
        _repo.Update(item);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var existing = await _repo.GetByIdAsync(id, ct);
        if (existing is null) return;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
    }

    private static void Validate(ServiceCatalogItem s)
    {
        if (string.IsNullOrWhiteSpace(s.Name)) throw new ArgumentException("Service name is required.");
        if (s.Price < 0) throw new ArgumentException("Price must be >= 0.");
        if (s.DurationMinutes <= 0) throw new ArgumentException("DurationMinutes must be > 0.");
    }
}
