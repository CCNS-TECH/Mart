using System;
using System.Security.Cryptography;
using System.Text;

namespace resm_app.Infrastructures.Encrypts
{
    public static class PassHashing
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
        public static string EncryptPass(string pass)
        {
            var newPass = pass + "passw0rd";
            var enc = Encoding.GetEncoding(0);
            byte[] buffer = enc.GetBytes(newPass);
            var sha1 = SHA1.Create();
            var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }
    }
}
