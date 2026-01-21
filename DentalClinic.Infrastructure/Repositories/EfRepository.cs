using System.Linq.Expressions;
using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Infrastructure.Repositories;

public class EfRepository<T> : IRepository<T> where T : EntityBase
{
    private readonly DentalClinicDbContext _db;
    private readonly DbSet<T> _set;

    public EfRepository(DentalClinicDbContext db)
    {
        _db = db;
        _set = db.Set<T>();
    }

    public Task<T?> GetByIdAsync(int id, CancellationToken ct = default) =>
        _set.FirstOrDefaultAsync(x => x.Id == id, ct);

    public Task<List<T>> ListAsync(CancellationToken ct = default) =>
        _set.ToListAsync(ct);

    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default) =>
        _set.Where(predicate).ToListAsync(ct);

    public Task AddAsync(T entity, CancellationToken ct = default) =>
        _set.AddAsync(entity, ct).AsTask();

    public void Update(T entity) => _set.Update(entity);
    public void Remove(T entity) => _set.Remove(entity);

    public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
        _db.SaveChangesAsync(ct);
}
