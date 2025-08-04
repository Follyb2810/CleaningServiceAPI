using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CleaningServiceAPI.Modules.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Common;

namespace CleaningServiceAPI.Common
{
    public class JwtService
    {
        private readonly IConfiguration _config;
        private readonly JwtOptions _jwt;


        public JwtService(IConfiguration config, JwtOptions jwt)
        {
            _config = config;
            _jwt = jwt;
        }

        public string GenerateToken(UserModel user, IList<string> roles)
        {
            var claims = new List<Claim>
        {
                //  new Claim(ClaimTypes.NameIdentifier, user.Id),
                // new Claim(JwtRegisteredClaimNames.Sub, user.Id),
    
                 new Claim("id", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            // new Claim(ClaimTypes.Email, user.Email),
            // new Claim(ClaimTypes.Role, user.Role),

        };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );
            // var token = new JwtSecurityToken(
            // issuer: _jwt.Issuer,
            // audience: _jwt.Audience,
            // claims: claims,
            // expires: DateTime.UtcNow.AddHours(1),
            // signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}