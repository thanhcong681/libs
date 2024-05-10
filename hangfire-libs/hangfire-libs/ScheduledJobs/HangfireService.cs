using System.Linq.Expressions;
using Hangfire;

namespace hangfire_libs.ScheduledJobs;

public class HangfireService : IScheduledJobService
{
    public string Enqueue(Expression<Action> functionCall)
    {
        return BackgroundJob.Enqueue(functionCall);
    }

    public string Enqueue<T>(Expression<Action<T>> functionCall)
    {
        return BackgroundJob.Enqueue(functionCall);
    }

    public string Schedule(Expression<Action> functionCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(functionCall, delay);
    }

    public string Schedule<T>(Expression<Action<T>> functionCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(functionCall, delay);
    }

    public string Schedule(Expression<Action> functionCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(functionCall, enqueueAt);
    }

    public string ContinueQueueWith(string parentJobId, Expression<Action> functionCall)
    {
        return BackgroundJob.ContinueJobWith(parentJobId, functionCall);
    }
    
    [Obsolete("Obsolete")]
    public void Recurring(string jobId, Expression<Action> functionCall, string cronExpression)
    {
        RecurringJob.AddOrUpdate(jobId, functionCall, cronExpression, TimeZoneInfo.Local);
    }
    
    [Obsolete("Obsolete")]
    public void Recurring(string jobId, Expression<Action> functionCall)
    {
        RecurringJob.AddOrUpdate(jobId, functionCall, Cron.Weekly(DayOfWeek.Tuesday, 21, 35), TimeZoneInfo.Local);
    }
    
    public bool Delete(string jobId)
    {
        return BackgroundJob.Delete(jobId);
    }

    public bool Requeue(string jobId)
    {
        return BackgroundJob.Requeue(jobId);
    }
}