using System;
using System.Collections.Generic;
using System.Text;
using Evento.Infrastructure.DTO;
using Evento.Infrastructure.Settings;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Evento.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Evento.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        //private readonly JwtSettings _settings;

        //public JwtHandler(JwtSettings settings)
        //{
        //    _settings = settings;
        //}

        public JwtDTO CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString())
            };

            var expiry = now.AddMinutes(20);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super_secret_key123!")), 
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "http://localhost:57349",
                claims: claims,
                notBefore: now,
                expires: expiry,
                signingCredentials: signingCredentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDTO
            {
                Token = token,
                Expires = expiry.ToTimestamp()
            };
        }
    }
}
