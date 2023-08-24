using JohnyStoreApi.Data.Models;
using JohnyStoreApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JohnyStoreApi.Services.AdditionalServices
{
    public class JWT : IJWT, IPasswordManager
    {
        private readonly IConfiguration configuration;
        /// <summary>
        /// секретный ключ
        /// </summary>        
        /// <summary>       
        private byte[] key;
        public JWT(IConfiguration configuration)
        {
            this.configuration = configuration;
            var secretKey = configuration.GetValue<string>("JwtSettings:SecretKey");
            key = Encoding.UTF8.GetBytes(secretKey);
        }

        /// <summary>
        /// Генерация токена
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string GenerateJWT(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] //утверждения которые будут храниться в токене
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName), //UserName
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //Идентификатор токена
                new Claim(ClaimTypes.Role, userInfo.Role) //Роль
            };

            var token = new JwtSecurityToken( //создание токена
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); //Преобразование токена в строку
        }

        /// <summary>
        /// Хэширование пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var argHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(argHash);
            }
        }
    }
}
