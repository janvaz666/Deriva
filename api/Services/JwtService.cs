using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public class JwtService
    {
        #region propiedades
        #endregion

        #region variables

        private readonly string secret;
        private readonly string expDate;
        private readonly string issuer;

        #endregion

        #region constructores

        public JwtService(IConfiguration config)
        {
            secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
            issuer = config.GetSection("JwtConfig").GetSection("issuer").Value;
        }

        #endregion

        #region método públicos

        /// <summary>
        /// Generar token de seguridad
        /// </summary>
        /// <param name="email">Correo electrónico</param>
        /// <returns>Cadena con el token generado</returns>
        public string GenerateSecurityToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = issuer,
                Issuer = issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        #endregion
    }
}
