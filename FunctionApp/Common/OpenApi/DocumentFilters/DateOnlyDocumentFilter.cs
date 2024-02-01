using Microsoft.OpenApi.Models;

namespace FunctionApp.Common.OpenApi.DocumentFilters;

public class DateOnlyDocumentFilter : CustomTypeDocumentFilter<DateOnly>
{
    public DateOnlyDocumentFilter() 
        : base(new OpenApiSchema
        {
            Type = "string",
            Format = "date",
        })
    {
    }
}
