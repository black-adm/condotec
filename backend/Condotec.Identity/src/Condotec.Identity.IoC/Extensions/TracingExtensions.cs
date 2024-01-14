using Condotec.Identity.Data.Constants;
using Condotec.Identity.IoC.Models;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Condotec.Identity.IoC.Extensions
{
    public static class TracingExtensions
    {
        public static IServiceCollection AddTracing(this IServiceCollection services, TracingSettings? tracingSettings)
        {
            services.AddOpenTelemetry().WithTracing(tcb =>
            {
                tcb
                .AddSource(Tracing.ApplicationName)
                .SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(serviceName: Tracing.ApplicationName))
                .AddSqlClientInstrumentation(options => options.SetDbStatementForText = true)
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(opt =>
                 {
                     opt.Endpoint = new Uri(tracingSettings?.Uri + ":" + tracingSettings?.Port);
                     opt.Protocol = OtlpExportProtocol.Grpc;
                 });
             });

            services.AddSingleton(TracerProvider.Default.GetTracer(Tracing.ApplicationName));

            return services;
        }
    }
}
