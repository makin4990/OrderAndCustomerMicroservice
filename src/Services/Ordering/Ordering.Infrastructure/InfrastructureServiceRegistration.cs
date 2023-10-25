using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Services.ValidateCustomer;

namespace Ordering.Application;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        services.AddScoped<ICustomerValidationService, CustomerValidationService>();
       


        return services;

    }
}