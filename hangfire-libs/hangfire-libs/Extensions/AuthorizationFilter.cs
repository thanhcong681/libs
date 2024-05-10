using Hangfire.Dashboard;

namespace hangfire_libs.Extensions;

public class AuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}