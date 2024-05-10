using Hangfire;
using hangfire_libs.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace hangfire_libs.Extensions;

public static class HangfireExtensions
{
    public static IServiceCollection AddHangfireService(this IServiceCollection services)
    {
        var settings = services.GetOptions<HangfireSettings>("HangFireSettings");
        if (settings == null || settings.Storage == null ||
            string.IsNullOrEmpty(settings.Storage.ConnectionString))
            throw new Exception("HangFireSettings is not configured properly!");

        services.ConfigureHangfireServices(settings);
        services.AddHangfireServer(serverOptions =>
        {
            serverOptions.ServerName = settings.ServerName;
        });

        return services;
    }
    
    private static IServiceCollection ConfigureHangfireServices(this IServiceCollection services, HangfireSettings settings)
    {
        if (string.IsNullOrEmpty(settings.Storage.DBProvider))
            throw new Exception("HangFire DBProvider is not configured.");

        switch (settings.Storage.DBProvider.ToLower())
        {
            case "mongodb":
                
                break;
            case "postgresql":
                // services.AddHangfire(x =>
                //     x.UsePostgreSqlStorage(settings.Storage.ConnectionString));
                break;

            case "mssql":
                services.AddHangfire(x =>
                    x.UseSqlServerStorage(settings.Storage.ConnectionString));
                break;

            default:
                throw new Exception($"HangFire Storage Provider {settings.Storage.DBProvider} is not supported.");
        }

        return services;
    }
}