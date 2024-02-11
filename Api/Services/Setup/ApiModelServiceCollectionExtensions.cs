using Api.Services.Dependents;
using Api.Services.Employes;
using Api.Services.Paychecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Services.Setup;

public static class ApiServicesServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDependentService, DependentService>();
        services.AddTransient<IEmployeeService, EmployeeService>();

        services.AddTransient<IPaycheckCalculationService, PaycheckCalculationService>();
        services.AddPaycheckRules();
        
        return services;
    }
    
    private static IServiceCollection AddPaycheckRules(this IServiceCollection services)
    {
        services.AddTransient<IPaycheckCalculationRule, BaseBenefitsCostRule>();
        services.AddTransient<IPaycheckCalculationRule, DependentCostRule>();
        services.AddTransient<IPaycheckCalculationRule, HighEarnerRule>();
        services.AddTransient<IPaycheckCalculationRule, OlderDependentAdditionalCostRule>();
        return services;
    } 
}
