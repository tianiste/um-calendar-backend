namespace UmCalendar.Services
{
    public static class PasswordHelper
    {
        public static string GenerateSalt(int size = 32)
        {
            var buffer = new byte[size];
            System.Security.Cryptography.RandomNumberGenerator.Fill(buffer);
            return Convert.ToBase64String(buffer);
        }

        public static string HashPassword(string password, string salt, int iterations = 100_000, int hashByteSize = 32)
        {
            var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), iterations, System.Security.Cryptography.HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(hashByteSize);
            return Convert.ToBase64String(hash);
        }
    }
}