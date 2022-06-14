namespace InvestManager.WebApi.Infrastructure.Authorization
{
    using System;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;

    public static class AuthorizationParameters
    {
        public static TokenValidationParameters GetTokenValidationParameters(string signingKey) => new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
        };
    }
}