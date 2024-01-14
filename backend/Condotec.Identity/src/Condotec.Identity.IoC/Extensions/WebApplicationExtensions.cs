using Condotec.Identity.Data.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Condotec.Identity.IoC.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void RunMigrationsOnApplicationStart(this WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<IdentityDataContext>();
            dataContext.Database.Migrate();
        }
    }
}
