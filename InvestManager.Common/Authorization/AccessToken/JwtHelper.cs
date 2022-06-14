namespace InvestManager.Common.Authorization.AccessToken
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using ExpiresInterval;
    using Microsoft.IdentityModel.Tokens;

    public static class JwtHelper
    {
        public static string CreateJwtToken(JwtTokenConfiguration configuration, long userId, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.UserId, userId.ToString()),
                new Claim(ClaimTypes.UserName, userName),
                new Claim("jti", Guid.NewGuid().ToString())
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.SigningKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(configuration.ExpiresInterval.ToTimeSpan()),
                claims: claims,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}