using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Model.Setup;

public static class ApiModelServiceCollectionExtensions
{
    public static IServiceCollection AddApiContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ApiContext")));
        
        return services;
    }
}
