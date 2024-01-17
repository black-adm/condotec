using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CondoTec.Management.API.Extensions
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, string? auth)
        {
            if (!string.IsNullOrEmpty(auth))
            {
                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(auth)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            }

            return services;
        }
    }
}
