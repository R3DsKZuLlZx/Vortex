using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FunctionApp.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureSingletonOptionAndValidate<T>(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        string section)
        where T : class, new()
    {
        return serviceCollection
            .AddOptions<T>()
            .Bind(configuration.GetSection(section))
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services
            .AddSingleton(s => s.GetRequiredService<IOptions<T>>().Value);
    }
}
