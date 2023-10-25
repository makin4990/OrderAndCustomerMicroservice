using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Hangfire.Services;
using System.Reflection;

namespace Ordering.Hangfire;

public static class HangfireServiceRegistration
{
    public static IServiceCollection AddHangfireServices(this IServiceCollection services)
    {

        services.AddTransient<IDailyLogService,DailyLogService>();
        services.AddHangfire(x => x.UsePostgreSqlStorage("User ID=makin19;Password=Muhammed1453;Host=81.0.220.136;Port=5432;Database=Tesodev;"));
        services.AddHangfireServer(i=> new BackgroundJobServerOptions());

        return services;

    }
}