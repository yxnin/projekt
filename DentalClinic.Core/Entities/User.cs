namespace DentalClinic.Core.Entities;

public class User : EntityBase
{
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = ""; // salt:hash
    public string Role { get; set; } = "User";     // Admin/User

    // powiązanie z pacjentem (dla panelu usera)
    public int? PatientId { get; set; }
    public Patient? Patient { get; set; }
}

public static class UserRoles
{
    public const string Admin = "Admin";
    public const string User = "User";
}
