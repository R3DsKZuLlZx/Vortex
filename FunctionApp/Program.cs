using FunctionApp.Common.Extensions;
using Howden.Azure.Worker.Extensions.Converters;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(x =>
    {
        x.UseMiddleware<JsonBodyExceptionMiddleware>();
    })
    .ConfigureOpenApi()
    .ConfigureServices((context, services) => services.AddCustomServices(context.Configuration))
    .Build();

host.Run();
