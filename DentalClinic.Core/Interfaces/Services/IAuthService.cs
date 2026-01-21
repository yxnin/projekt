using DentalClinic.Core.Entities;

namespace DentalClinic.Core.Interfaces.Services;

public interface IAuthService
{
    Task<User> RegisterAsync(string email, string password, string role = UserRoles.User, CancellationToken ct = default);
    Task<User?> LoginAsync(string email, string password, CancellationToken ct = default);
}
