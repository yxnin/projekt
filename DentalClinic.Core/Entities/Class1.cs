namespace DentalClinic.Core.Entities;

public class Patient : Person
{
    public DateOnly? BirthDate { get; set; }
}

public class Dentist : Person
{
    public string Specialization { get; set; } = "";
}

public class ServiceCatalogItem : EntityBase
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }
}

public class Appointment : EntityBase
{
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    public int DentistId { get; set; }
    public Dentist? Dentist { get; set; }

    public int ServiceCatalogItemId { get; set; }
    public ServiceCatalogItem? Service { get; set; }

    public DateTime StartUtc { get; set; }
    public string Status { get; set; } = "Scheduled"; // np. Scheduled/Cancelled/Done
}

public class User : EntityBase
{
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Role { get; set; } = "User"; // Admin/User
}