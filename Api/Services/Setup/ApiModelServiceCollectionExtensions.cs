using Api.Services.Dependents;
using Api.Services.Employes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Services.Setup;

public static class ApiServicesServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDependentService, DependentService>();
        services.AddTransient<IEmployeeService, EmployeeService>();
        
        return services;
    }
}
