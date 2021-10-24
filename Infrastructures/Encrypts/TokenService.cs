using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace resm_app.Infrastructures.Encrypts
{
    public partial class TokenService
    {
        public IConfiguration _configuration { get; }
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(SecurityKey key, string credentailsName, string role)
        {
            var now = DateTime.UtcNow;
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];
            var claims = new Collection<Claim>
            {
                new Claim(ClaimTypes.Name, credentailsName),
                new Claim(ClaimTypes.Role, role)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateJwtSecurityToken(issuer, audience, identity, now, now.AddDays(1), now, signingCredentials);

            var encodeJwt = handler.WriteToken(token);
            return encodeJwt;

        }
    }
}
