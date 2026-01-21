using DentalClinic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

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
        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
    }
}