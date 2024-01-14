using Condotec.Identity.Application.Services;
using Condotec.Identity.Data.Data;
using Condotec.Identity.IoC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Condotec.Identity.IoC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services, SqlServerSettings? sqlserver)
        {
            services.AddDbContext<IdentityDataContext>(options =>
                options.UseSqlServer(sqlserver?.ConnectionString ?? throw new Exception("Invalid sqlserver connection string"))
            );

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
