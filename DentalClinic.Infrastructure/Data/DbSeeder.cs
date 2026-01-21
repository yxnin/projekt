using DentalClinic.Core.Entities;
using DentalClinic.Core.Security;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(DentalClinicDbContext db, CancellationToken ct = default)
    {
        // Users
        if (!await db.Users.AnyAsync(ct))
        {
            db.Users.Add(new User
            {
                Email = "admin@clinic.local",
                PasswordHash = PasswordHasher.Hash("Admin123!"),
                Role = UserRoles.Admin
            });
        }

        // Dentists
        if (!await db.Dentists.AnyAsync(ct))
        {
            db.Dentists.AddRange(
                new Dentist { FirstName = "Jan", LastName = "Kowalski", Phone = "500100200", Specialization = "Endodoncja" },
                new Dentist { FirstName = "Anna", LastName = "Nowak", Phone = "500300400", Specialization = "Chirurgia" }
            );
        }

        // Services
        if (!await db.Services.AnyAsync(ct))
        {
            db.Services.AddRange(
                new ServiceCatalogItem { Name = "Przegląd", Price = 100m, DurationMinutes = 20 },
                new ServiceCatalogItem { Name = "Wypełnienie", Price = 250m, DurationMinutes = 45 },
                new ServiceCatalogItem { Name = "Kanałowe", Price = 900m, DurationMinutes = 90 }
            );
        }

        // Patients
        if (!await db.Patients.AnyAsync(ct))
        {
            db.Patients.AddRange(
                new Patient { FirstName = "Michał", LastName = "Testowy", Phone = "600111222", BirthDate = new DateOnly(2000, 1, 1) },
                new Patient { FirstName = "Karolina", LastName = "Przykład", Phone = "600333444", BirthDate = new DateOnly(1999, 5, 10) }
            );
        }

        await db.SaveChangesAsync(ct);
    }
}
