using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace FunctionApp.Functions;

public abstract class FunctionBase
{
    protected static EmptyResult Empty { get; } = new();

    protected virtual StatusCodeResult StatusCode(int statusCode)
        => new(statusCode);

    protected virtual ObjectResult StatusCode(int statusCode, object? value)
        => new(value) { StatusCode = statusCode };

    protected virtual ContentResult Content(string content)
        => Content(content, (MediaTypeHeaderValue?)null);

    protected virtual ContentResult Content(string content, string contentType)
        => Content(content, MediaTypeHeaderValue.Parse((StringSegment)contentType));

    protected virtual ContentResult Content(
        string content,
        string contentType,
        Encoding? contentEncoding)
    {
        var mediaTypeHeaderValue = MediaTypeHeaderValue.Parse(contentType);
        mediaTypeHeaderValue.Encoding = contentEncoding ?? mediaTypeHeaderValue.Encoding;
        return Content(content, mediaTypeHeaderValue);
    }

    protected virtual ContentResult Content(string content, MediaTypeHeaderValue? contentType)
    {
        return new ContentResult
        {
            Content = content,
            ContentType = contentType?.ToString(),
        };
    }

    protected virtual NoContentResult NoContent()
        => new();

    protected virtual OkResult Ok()
        => new();

    protected virtual OkObjectResult Ok(object? value)
        => new(value);

    protected virtual FileContentResult File(byte[] fileContents, string contentType)
        => File(fileContents, contentType, fileDownloadName: null);

    protected virtual FileContentResult File(byte[] fileContents, string contentType, bool enableRangeProcessing)
        => File(fileContents, contentType, fileDownloadName: null, enableRangeProcessing);

    protected virtual FileContentResult File(byte[] fileContents, string contentType, string? fileDownloadName)
        => new(fileContents, contentType) { FileDownloadName = fileDownloadName };

    protected virtual FileContentResult File(
        byte[] fileContents,
        string contentType,
        string? fileDownloadName,
        bool enableRangeProcessing)
        => new(fileContents, contentType)
        {
            FileDownloadName = fileDownloadName,
            EnableRangeProcessing = enableRangeProcessing,
        };

    protected virtual FileContentResult File(
        byte[] fileContents,
        string contentType,
        DateTimeOffset? lastModified,
        EntityTagHeaderValue entityTag)
        => new(fileContents, contentType)
        {
            LastModified = lastModified,
            EntityTag = entityTag,
        };

    protected virtual FileContentResult File(
        byte[] fileContents,
        string contentType,
        DateTimeOffset? lastModified,
        EntityTagHeaderValue entityTag,
        bool enableRangeProcessing)
        => new(fileContents, contentType)
        {
            LastModified = lastModified,
            EntityTag = entityTag,
            EnableRangeProcessing = enableRangeProcessing,
        };

    protected virtual FileContentResult File(
        byte[] fileContents,
        string contentType,
        string? fileDownloadName,
        DateTimeOffset? lastModified,
        EntityTagHeaderValue entityTag)
        => new(fileContents, contentType)
        {
            LastModified = lastModified,
            EntityTag = entityTag,
            FileDownloadName = fileDownloadName,
        };

    protected virtual FileContentResult File(
        byte[] fileContents,
        string contentType,
        string? fileDownloadName,
        DateTimeOffset? lastModified,
        EntityTagHeaderValue entityTag,
        bool enableRangeProcessing)
        => new(fileContents, contentType)
        {
            LastModified = lastModified,
            EntityTag = entityTag,
            FileDownloadName = fileDownloadName,
            EnableRangeProcessing = enableRangeProcessing,
        };

    protected virtual FileStreamResult File(Stream fileStream, string contentType)
        => File(fileStream, contentType, fileDownloadName: null);

    protected virtual FileStreamResult File(
        Stream fileStream,
        string contentType,
        bool enableRangeProcessing)
        => File(fileStream, contentType, fileDownloadName: null, enableRangeProcessing);

    protected virtual FileStreamResult File(
        Stream fileStream,
        string contentType,
        string? fileDownloadName)
        => new(fileStream, contentType)
        {
            FileDownloadName = fileDownloadName,
        };

    protected virtual FileStreamResult File(
        Stream fileStream,
        string contentType,
        string? fileDownloadName,
        bool enableRangeProcessing)
        => new(fileStream, contentType)
        {
            FileDownloadName = fileDownloadName,
            EnableRangeProcessing = enableRangeProcessing,
        };

    protected virtual FileStreamResult File(
        Stream fileStream,
        string contentType,
        DateTimeOffset? lastModified,
        EntityTagHeaderValue entityTag)
        => new(fileStream, contentType)
        {
            LastModified = lastModified,
            EntityTag = entityTag,
        };

    protected virtual FileStreamResult File(
        Stream fileStream,
        string contentType,
        DateTimeOffset? lastModified,
        EntityTagHeaderValue entityTag,
        bool enableRangeProcessing)
        => new(fileStream, contentType)
        {
            LastModified = lastModified,
            EntityTag = entityTag,
            EnableRangeProcessing = enableRangeProcessing,
        };

    protected virtual FileStreamResult File(
        Stream fileStream,
        string contentType,
        string? fileDownloadName,
        DateTimeOffset? lastModified,
        EntityTagHeaderValue entityTag)
        => new(fileStream, contentType)
        {
            FileDownloadName = fileDownloadName,
            LastModified = lastModified,
            EntityTag = entityTag,
        };

    protected virtual FileStreamResult File(
        Stream fileStream,
        string contentType,
        string? fileDownloadName,
        DateTimeOffset? lastModified,
        EntityTagHeaderValue entityTag,
        bool enableRangeProcessing)
        => new(fileStream, contentType)
        {
            FileDownloadName = fileDownloadName,
            LastModified = lastModified,
            EntityTag = entityTag,
            EnableRangeProcessing = enableRangeProcessing,
        };

    protected virtual UnauthorizedResult Unauthorized()
        => new();

    protected virtual NotFoundResult NotFound()
        => new();

    protected virtual NotFoundObjectResult NotFound(object? value)
        => new(value);

    protected virtual BadRequestResult BadRequest()
        => new();

    protected virtual BadRequestObjectResult BadRequest(object? error)
        => new(error);

    protected virtual BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
        => modelState != null
            ? new BadRequestObjectResult(modelState)
            : throw new ArgumentNullException(nameof(modelState));

    protected virtual UnprocessableEntityResult UnprocessableEntity()
        => new();

    protected virtual UnprocessableEntityObjectResult UnprocessableEntity(object? error)
        => new(error);

    protected virtual UnprocessableEntityObjectResult UnprocessableEntity(ModelStateDictionary modelState)
        => modelState != null
            ? new UnprocessableEntityObjectResult(modelState)
            : throw new ArgumentNullException(nameof(modelState));

    protected virtual ConflictResult Conflict()
        => new();

    protected virtual ConflictObjectResult Conflict(object? error)
        => new(error);

    protected virtual ConflictObjectResult Conflict(ModelStateDictionary modelState)
        => new(modelState);

    protected virtual ActionResult ValidationProblem(ValidationProblemDetails descriptor)
    {
        ArgumentNullException.ThrowIfNull(descriptor);

        return new BadRequestObjectResult(descriptor);
    }

    protected virtual CreatedResult Created(string uri, object? value)
        => new(uri, value);

    protected virtual CreatedResult Created(Uri uri, object? value)
        => new(uri, value);

    protected virtual AcceptedResult Accepted()
        => new();

    protected virtual AcceptedResult Accepted(object? value)
        => new(location: null, value);

    protected virtual AcceptedResult Accepted(Uri uri)
        => new(uri, value: null);

    protected virtual AcceptedResult Accepted(string? uri)
        => new(uri, value: null);

    protected virtual AcceptedResult Accepted(string? uri, object? value)
        => new(uri, value);

    protected virtual AcceptedResult Accepted(Uri uri, object? value)
        => new(uri, value);

    protected virtual ChallengeResult Challenge()
        => new();

    protected virtual ChallengeResult Challenge(params string[] authenticationSchemes)
        => new(authenticationSchemes);

    protected virtual ChallengeResult Challenge(AuthenticationProperties properties)
        => new(properties);

    protected virtual ChallengeResult Challenge(
        AuthenticationProperties properties,
        params string[] authenticationSchemes)
        => new(authenticationSchemes, properties);

    protected virtual ForbidResult Forbid()
        => new();

    protected virtual ForbidResult Forbid(params string[] authenticationSchemes)
        => new(authenticationSchemes);

    protected virtual ForbidResult Forbid(AuthenticationProperties properties)
        => new(properties);

    protected virtual ForbidResult Forbid(AuthenticationProperties properties, params string[] authenticationSchemes) 
        => new(authenticationSchemes, properties);
}
