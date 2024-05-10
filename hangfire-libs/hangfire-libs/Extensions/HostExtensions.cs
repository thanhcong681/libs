using Hangfire;
using hangfire_libs.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace hangfire_libs.Extensions;

public static class HostExtensions
{
    public static IApplicationBuilder UseHangfireDashboard(this IApplicationBuilder app, IConfiguration configuration)
    {
        var configDashboard = configuration.GetSection("HangFireSettings:Dashboard").Get<DashboardOptions>();
        var hangfireSettings = configuration.GetSection("HangFireSettings").Get<HangfireSettings>();
        var hangfireRoute = hangfireSettings!.Route;
        
        app.UseHangfireDashboard(hangfireRoute, new DashboardOptions
        {
            Authorization = new[] { new AuthorizationFilter() },
            DashboardTitle = configDashboard!.DashboardTitle,
            StatsPollingInterval = configDashboard.StatsPollingInterval,
            AppPath = configDashboard.AppPath,
            IgnoreAntiforgeryToken = true
        });

        return app;
    }
}