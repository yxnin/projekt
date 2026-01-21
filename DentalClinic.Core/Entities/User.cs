using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Core.Entities;

public class User : EntityBase
{
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = ""; // format: salt:hash
    public string Role { get; set; } = "User";     // Admin/User
}

public static class UserRoles
{
    public const string Admin = "Admin";
    public const string User = "User";
}
