using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp.Common.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCustomServices(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration)
    {
        // Add services to the container.
        return serviceCollection;
    }
}
