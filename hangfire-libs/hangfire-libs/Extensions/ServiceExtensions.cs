using hangfire_libs.Configurations;
using hangfire_libs.ScheduledJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hangfire_libs.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddHangfireConfigurationSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        var hangFireSettings = configuration.GetSection(nameof(HangfireSettings))
            .Get<HangfireSettings>();
        services.AddSingleton(hangFireSettings!);

        return services;
    }

    public static IServiceCollection AddHangfireConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IScheduledJobService, HangfireService>();
        return services;
    }
}