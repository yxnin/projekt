using System.Security.Cryptography;
using System.Text;

namespace DentalClinic.Core.Security;

// format: saltHex:hashHex
public static class PasswordHasher
{
    public static string Hash(string password)
    {
        password ??= "";
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Sha256(Combine(salt, Encoding.UTF8.GetBytes(password)));
        return $"{Convert.ToHexString(salt)}:{Convert.ToHexString(hash)}";
    }

    public static bool Verify(string password, string stored)
    {
        password ??= "";

        var parts = (stored ?? "").Split(':');
        if (parts.Length != 2) return false;

        var salt = Convert.FromHexString(parts[0]);
        var expected = Convert.FromHexString(parts[1]);

        var actual = Sha256(Combine(salt, Encoding.UTF8.GetBytes(password)));
        return CryptographicOperations.FixedTimeEquals(expected, actual);
    }

    private static byte[] Sha256(byte[] data)
    {
        using var sha = SHA256.Create();
        return sha.ComputeHash(data);
    }

    private static byte[] Combine(byte[] a, byte[] b)
    {
        var r = new byte[a.Length + b.Length];
        Buffer.BlockCopy(a, 0, r, 0, a.Length);
        Buffer.BlockCopy(b, 0, r, a.Length, b.Length);
        return r;
    }
}
