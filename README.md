# Vortex Solution Template

[![Nuget](https://img.shields.io/nuget/v/Vortex.Solution.Template?label=NuGet)](https://www.nuget.org/packages/Vortex.Solution.Template)
[![Nuget](https://img.shields.io/nuget/dt/Vortex.Solution.Template?label=Downloads)](https://www.nuget.org/packages/Vortex.Solution.Template)

The goal of this template is to make the transition from ASP.NET Web APIs to Azure Functions as seamless as possible.

If you find this project useful, please give it a star. Thanks! ⭐

## Getting Started

The easiest way to get started is to install the [.NET template](https://www.nuget.org/packages/Vortex.Solution.Template):
```
dotnet new install Vortex.Solution.Template::1.0.0
```

To create a new solution:
```bash
dotnet new vtx-sln -n YourSolutionName
```

Add the following to the FunctionApp project:
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
  }
}
```

## Technologies

* [Azure Functions 4](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview)
* [ASP.NET Core 8](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 8](https://docs.microsoft.com/en-us/ef/core/)

## Support

If you are having problems, please let me know by raising a new issue.

## License

Feel free to do what you want.