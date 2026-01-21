using DentalClinic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DentalClinic.Infrastructure.Data;

public class DentalClinicDbContext : DbContext
{
    public DentalClinicDbContext(DbContextOptions<DentalClinicDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Dentist> Dentists => Set<Dentist>();
    public DbSet<ServiceCatalogItem> Services => Set<ServiceCatalogItem>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // DateOnly? converter for SQLite (bez niespodzianek)
        var dateOnlyNullableConverter = new ValueConverter<DateOnly?, string?>(
            v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null,
            v => string.IsNullOrWhiteSpace(v) ? (DateOnly?)null : DateOnly.Parse(v));

        modelBuilder.Entity<Patient>()
            .Property(p => p.BirthDate)
            .HasConversion(dateOnlyNullableConverter);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Dentist)
            .WithMany()
            .HasForeignKey(a => a.DentistId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Service)
            .WithMany()
            .HasForeignKey(a => a.ServiceCatalogItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
