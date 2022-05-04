using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MovieSiteProject.Core.Utilities.Security.Encryption;
using MovieSiteProject.Core.Utilities.Security.Jwt;

namespace MovieSiteProject.Extensions
{
    public static class AddJwtAuthenticationExtensions
    {
        public static AuthenticationBuilder AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
        }
    }
}