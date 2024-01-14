using Condotec.Identity.IoC.Models;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Condotec.Identity.IoC.Extensions
{
    public static class HealthCheckExtensions
    {
        private static readonly string[] tags = ["db", "data"];

        public static IServiceCollection AddHealthCheckers(this IServiceCollection services, SqlServerSettings? settings)
        {
            if (settings?.ConnectionString is not null)
            {
                services
                    .AddHealthChecks()
                    .AddSqlServer(settings.ConnectionString, name: "SqlServer", tags: tags);

                services
                    .AddHealthChecksUI()
                    .AddInMemoryStorage();
            }

            return services;
        }

        public static void UseHealthCheckers(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => options.UIPath = "/monitor");
        }
    }
}
