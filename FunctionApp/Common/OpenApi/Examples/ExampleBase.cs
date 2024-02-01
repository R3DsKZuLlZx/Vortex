using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FunctionApp.Common.OpenApi.Examples;

public abstract class ExampleBase<T> : OpenApiExample<T>
{
    protected ExampleBase(T example)
    {
        Example = example;
    }

    private T Example { get; }
    
    public override IOpenApiExample<T> Build(NamingStrategy? namingStrategy = null)
    {
        var json = JsonConvert.SerializeObject(Example);
        
        Examples.Add(
            typeof(T).Name,
            new OpenApiExample
            {
                Value = new OpenApiString(json),
            });

        return this;
    }
}
