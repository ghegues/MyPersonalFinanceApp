using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace MyPersonalFinanceApp.Application.Utils
{
    public class PasswordHasher
    {
        private readonly string _hashSalt;

        public PasswordHasher(IConfiguration configuration)
        {
            _hashSalt = configuration["HashSalt"];
        }

        public string HashPassword(string password)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(_hashSalt);
            byte[] hashedBytes = KeyDerivation.Pbkdf2(password, saltBytes, KeyDerivationPrf.HMACSHA256, 10000, 256 / 8);
            return Convert.ToBase64String(hashedBytes);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string computedHash = HashPassword(password);
            return hashedPassword == computedHash;
        }
    }
}
