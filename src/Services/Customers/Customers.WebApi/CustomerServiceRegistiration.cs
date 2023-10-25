using Customers.WebApi.BussinesRules;
using Customers.WebApi.Extentions;
using Customers.WebApi.Models;
using Customers.WebApi.Repository;
using Customers.WebApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Customers.WebApi;

public static class CustomerServiceRegistiration
{
    public static IServiceCollection AddCustomerServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.Configure<DbConfiguration>(configuration.GetSection("MongoDbConnection"));
        services.AddScoped<CreateCustomerBussinesRule>();
        return services;
    }
}
