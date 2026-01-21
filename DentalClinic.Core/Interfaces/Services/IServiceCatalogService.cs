using DentalClinic.Core.Entities;

namespace DentalClinic.Core.Interfaces.Services;

public interface IServiceCatalogService
{
    Task<ServiceCatalogItem> CreateAsync(ServiceCatalogItem item, CancellationToken ct = default);
    Task<ServiceCatalogItem?> GetAsync(int id, CancellationToken ct = default);
    Task<List<ServiceCatalogItem>> GetAllAsync(CancellationToken ct = default);
    Task UpdateAsync(ServiceCatalogItem item, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}
