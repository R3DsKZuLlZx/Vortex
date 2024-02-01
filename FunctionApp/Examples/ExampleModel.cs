using System.ComponentModel.DataAnnotations;

namespace FunctionApp.Examples;

public class ExampleModel
{
    [Required]
    public string Message { get; set; } = string.Empty;
}
