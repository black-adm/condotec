using CondoTec.Management.Application.Commands.Condominios.UseCases.AddCondominio;

namespace CondoTec.Management.API.Extensions
{
    public static class MediatRExtension
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(
                    x => x.RegisterServicesFromAssemblies(
                        typeof(AddCondominioCommand).Assembly));

            return services;
        }
    }
}
