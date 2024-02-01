using System.Net;
using System.Net.Mime;
using FunctionApp.Examples.LookupExample;
using Howden.Azure.Worker.Extensions.Converters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace FunctionApp.Functions.Examples;

public class LookupExample : FunctionBase
{
    private readonly ILogger<LookupExample> _logger;

    public LookupExample(ILogger<LookupExample> logger)
    {
        _logger = logger;
    }

    [Function("LookupExample")]
    [OpenApiOperation("LookupExample", tags: ["Examples"], Description = "")]
    [OpenApiParameter("id", Required = true, Description = "")]
    [OpenApiRequestBody(MediaTypeNames.Application.Json, typeof(LookupExampleRequest), Description = "")]
    [OpenApiResponseWithBody(HttpStatusCode.OK, MediaTypeNames.Application.Json, typeof(LookupExampleResponse), Description = "")]
    [OpenApiResponseWithoutBody(HttpStatusCode.BadRequest, Description = "")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "examples/lookup/{id}")]
        HttpRequest request,
        FunctionContext executionContext,
        string id,
        [JsonBody] LookupExampleRequest model)
    {
        _logger.LogInformation("Vortex worked!");

        if (id != "Test")
        {
            return BadRequest("Id must be 'Test'.");
        }

        var response = new LookupExampleResponse(id, model.ExampleModel);
        
        return Ok(response);
    }
}
