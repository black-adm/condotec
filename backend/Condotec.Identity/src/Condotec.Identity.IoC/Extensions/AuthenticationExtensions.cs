using Condotec.Identity.Application.PolicyRequirements;
using Condotec.Identity.Data.Constants;
using Condotec.Identity.Data.Entities;
using Condotec.Identity.IoC.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace Condotec.Identity.IoC.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services, JwtOptionsSettings? settings)
        {
            if (settings is not null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.SecurityKey ?? throw new Exception("Invalid token security key")));

                services.Configure<JwtOptions>(options =>
                {
                    options.Issuer = settings.Issuer;
                    options.Audience = settings.Audience;
                    options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                    options.AccessTokenExpiration = settings.AccessTokenExpiration;
                    options.RefreshTokenExpiration = settings.RefreshTokenExpiration;
                });

                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                });

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = settings.Audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ClockSkew = TimeSpan.Zero
                };

                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options => options.TokenValidationParameters = tokenValidationParameters);
            }

            return services;
        }

        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, BusinessHours>();
            services
                .AddAuthorizationBuilder()
                .AddPolicy(Policies.HorarioComercial, policy =>
                    policy.Requirements.Add(new BusinessHourRequirement()));

            return services;
        }
    }
}
