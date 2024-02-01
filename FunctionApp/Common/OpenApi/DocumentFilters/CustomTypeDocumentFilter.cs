using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace FunctionApp.Common.OpenApi.DocumentFilters;

public class CustomTypeDocumentFilter<T> : IDocumentFilter
{
    private static readonly string _typeName = typeof(T).GetOpenApiTypeName(new CamelCaseNamingStrategy());
    private readonly OpenApiSchema _schema;

    public CustomTypeDocumentFilter(OpenApiSchema schema)
    {
        _schema = schema;
    }
    
    public void Apply(IHttpRequestDataObject req, OpenApiDocument document)
    {
        document.Components.Schemas[_typeName] = _schema;
    }
}
