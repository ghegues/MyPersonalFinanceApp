using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyPersonalFinanceApp.Domain.Entities;
using MyPersonalFinanceApp.JWT.Interfaces;

namespace MyPersonalFinanceApp.JWT.JWTService
{
    public class JWTService : IJWTService
    {
        private readonly string _secretKey;
        private readonly int _expirationInMinutes;

        public JWTService(IConfiguration configuration)
        {
            _secretKey = configuration["JWT:SecretKey"];
            _expirationInMinutes = int.Parse(configuration["JWT:ExpirationInMinutes"]);

        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_expirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var key2 = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(key2);
            }
            var securityKey = new SymmetricSecurityKey(key);

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var serializedUser = JsonSerializer.Serialize(new { token = tokenHandler.WriteToken(token), user.Id, user.Email, user.Name, tokenDescriptor.Expires});

            return serializedUser;
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out _);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
