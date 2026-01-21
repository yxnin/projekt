using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Security;

namespace DentalClinic.Core.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _users;

    public AuthService(IRepository<User> users)
    {
        _users = users;
    }

    public async Task<User> RegisterAsync(string email, string password, string role = UserRoles.User, CancellationToken ct = default)
    {
        email = (email ?? "").Trim().ToLowerInvariant();
        password ??= "";

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("Invalid email.");

        if (password.Length < 6)
            throw new ArgumentException("Password must be at least 6 characters.");

        if (role != UserRoles.Admin && role != UserRoles.User)
            throw new ArgumentException("Invalid role.");

        var existing = await _users.FindAsync(u => u.Email == email, ct);
        if (existing.Count > 0)
            throw new ArgumentException("Email already exists.");

        var user = new User
        {
            Email = email,
            PasswordHash = PasswordHasher.Hash(password),
            Role = role
        };

        await _users.AddAsync(user, ct);
        await _users.SaveChangesAsync(ct);
        return user;
    }

    public async Task<User?> LoginAsync(string email, string password, CancellationToken ct = default)
    {
        email = (email ?? "").Trim().ToLowerInvariant();
        password ??= "";

        var list = await _users.FindAsync(u => u.Email == email, ct);
        var user = list.FirstOrDefault();
        if (user is null) return null;

        return PasswordHasher.Verify(password, user.PasswordHash) ? user : null;
    }
}
