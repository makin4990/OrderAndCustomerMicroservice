using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Services.Repositories;
using Ordering.Persistence.Context;
using Ordering.Persistence.Repositories;

namespace Ordering.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TesodevDbContext>(options => options.UseNpgsql("User ID=<username>;Password=<password>;Host=81.0.220.136;Port=5432;Database=Tesodev;"));
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderLogRepository, OrderLogRepository>();
        return services;
    }
}