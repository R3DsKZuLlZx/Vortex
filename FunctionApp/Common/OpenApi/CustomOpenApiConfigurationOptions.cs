using FunctionApp.Common.OpenApi.DocumentFilters;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace FunctionApp.Common.OpenApi;

public sealed class CustomOpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
{
    public CustomOpenApiConfigurationOptions()
    {
        DocumentFilters.Add(new DateOnlyDocumentFilter());
    }
    
    public override OpenApiInfo Info { get; set; } = new OpenApiInfo
    {
        Title = "Vortex",
        Version = "1.0.0",
    };

    public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;
}
