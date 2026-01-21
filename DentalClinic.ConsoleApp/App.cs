using DentalClinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class App
{
    private readonly DentalClinicDbContext _db;
    private readonly AppSession _session;

    public App(DentalClinicDbContext db, AppSession session)
    {
        _db = db;
        _session = session;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("1) Register  2) Login  3) Exit");
            var choice = Console.ReadLine();

            if (choice == "1") await RegisterAsync();
            else if (choice == "2") await LoginAsync();
            else if (choice == "3") return;
        }
    }

    private async Task RegisterAsync()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        var pass = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
        {
            Console.WriteLine("Invalid email.");
            return;
        }
        if (pass.Length < 6)
        {
            Console.WriteLine("Password too short.");
            return;
        }

        if (await _db.Users.AnyAsync(u => u.Email == email))
        {
            Console.WriteLine("Email already exists.");
            return;
        }

        var user = new DentalClinic.Core.Entities.User
        {
            Email = email.Trim(),
            PasswordHash = SimpleHash(pass),
            Role = "User"
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        Console.WriteLine("Registered.");
    }

    private async Task LoginAsync()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        var pass = Console.ReadLine() ?? "";

        var hash = SimpleHash(pass);
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == hash);

        if (user is null)
        {
            Console.WriteLine("Bad credentials.");
            return;
        }

        _session.SignIn(user);
        Console.WriteLine($"Logged in as {user.Email}");
    }

    private static string SimpleHash(string input)
    {
        using var sha = System.Security.Cryptography.SHA256.Create();
        var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes);
    }
}