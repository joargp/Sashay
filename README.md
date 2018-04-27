Sashay  [![Build status](https://ci.appveyor.com/api/projects/status/5583ci3xog4i8gva?svg=true)](https://ci.appveyor.com/project/Jtango18/sashay)
=========

Sashay allows you to generate Swagger/OpenAPI Specification documentation from the code in precompiled Azure Functions.

Sashay closes a functionality gap that required if you're working with tooling (e.g. API Gateways) that require Swagger documentation relating to serverless function based API's on the Azure Stack.

Sashay currently targets .NET Standard 2.0.


## Getting Started ##

Sashay can be installed in to you Azure Function project using Nuget.

      Install-Package Sashay.AzureFunctions

or

    dotnet add package Sashay.AzureFunctions

Sashay is currently marked as a prerelease package because of a dependency on the [Azure WebJobs SDK](https://github.com/Azure/azure-webjobs-sdk). It will be updated as soon as the 3.0 final of the SDK is released.

## Generating Swagger 2.0 Documentation ##

After the NuGet package is installed, a sample Function will appear under a Samples folder in your project. This file is not compiled as part of your solution<sup>1</sup>.

The Swagger 2 Generation function code is below:

```csharp
[FunctionName("Swagger2")]
public static IActionResult Run([HttpTrigger("get", Route = "swagger")] HttpRequestMessage msg,
  TraceWriter log, ExecutionContext context)
{
    return new OkObjectResult(Swagger2Generator.GenerateFromRequestMessage(msg, context, log));
}
```

This code can be copied in to a new Class within your Function Project, compiled and deployed.

Once deployed, the generation Swagger can be accessed from the function endpoint/route of the Swagger function.

E.g.  `https://$YourFunctionApp$.azurewebsites.net/api/Swagger`

Sashay also works locally with the [Azure Function Core Tools](https://github.com/Azure/azure-functions-core-tools).

To generate the minimum required Swagger 2.0, each Azure Function will need to identify a response that it produces. At a minimum this requires the addition of the `ProducesResponseAttribute` to each Function endpoint.

E.g.

```csharp
[FunctionName("UsersFunction")]
[ProducesResponse(HttpStatusCode.OK)]
public static IActionResult Run([HttpTrigger("get", "post", Route = "Users")]HttpRequest req,
  TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    ...

}
```

## Generating Additional Information ##

** - Coming Soon - **





1 - [This behaviour](https://github.com/NuGet/Home/issues/1792) is due to an issue with Nuget's Package reference format now used in .NET Standard/Core
