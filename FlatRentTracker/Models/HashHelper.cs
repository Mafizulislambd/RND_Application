using System.Text;

namespace FlatRentTracker.Models
{
    // Helpers/HashHelper.cs
    public static class HashHelper
    {
        public static string HashPassword(string password)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }

}
