using Condotec.Management.Domain.Interfaces;
using Condotec.Management.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CondoTec.Management.IoC.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            return services;
        }
    }
}
