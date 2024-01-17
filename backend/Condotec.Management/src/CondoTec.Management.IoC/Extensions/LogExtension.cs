﻿using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;

namespace CondoTec.Management.IoC.Extensions
{
    public static class LogExtension
    {
        public static IServiceCollection AddLoggingDependency(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(new JsonFormatter())
                .CreateLogger();

            return services.AddSingleton(Log.Logger);
        }
    }
}
