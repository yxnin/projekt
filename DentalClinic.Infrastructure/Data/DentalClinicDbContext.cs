using DentalClinic.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Infrastructure.Data;

public class DentalClinicDbContext : DbContext
{
    public DentalClinicDbContext(DbContextOptions<DentalClinicDbContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>(b =>
        {
            b.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            b.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            b.Property(x => x.Phone).HasMaxLength(30);
        });
    }
}