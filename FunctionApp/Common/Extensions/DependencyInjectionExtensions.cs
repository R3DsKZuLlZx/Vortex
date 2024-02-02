#if (UseEfCore)
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
#if (UseEfCore)
using VortexDb;
#endif

namespace FunctionApp.Common.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCustomServices(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration)
    {
        // Add services to the container.
#if (UseEfCore)
        var connectionString = configuration.GetConnectionString(nameof(VortexDbContext)) ?? throw new InvalidOperationException("DbConnectionString not configured.");
        serviceCollection.AddDbContext<VortexDbContext>(options => options.UseSqlServer(connectionString));
#endif
        return serviceCollection;
    }
}
