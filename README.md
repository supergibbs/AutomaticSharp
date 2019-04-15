[![NuGet](https://img.shields.io/nuget/v/AutomaticSharp.svg)](https://www.nuget.org/packages/AutomaticSharp)
# AutomaticSharp 
A C# client for Automatic's REST API. 

## Usage

### Authentication

The [Automatic OAuth2 Workflow](https://developer.automatic.com/api-reference/#oauth-workflow) can be completed using the `Microsoft.AspNetCore.Authentication.OAuth` framework.

In a modern webapp you can add this to your `startup.cs`
```c#
services.AddAuthentication().AddAutomaticAuthentication(options =>
    {        
        //Add Automatic API key
        options.ClientId = Configuration["automatic:clientid"];
        options.ClientSecret = Configuration["automatic:clientsecret"];
        
        //Add desired scopes       
        options.AddScope(AutomaticScope.Public);
        options.AddScope(AutomaticScope.UserProfile);
        options.AddScope(AutomaticScope.Location);
        options.AddScope(AutomaticScope.VehicleEvents);
        options.AddScope(AutomaticScope.VehicleProfile);
        options.AddScope(AutomaticScope.Trip);
        options.AddScope(AutomaticScope.Behavior);       
    });

```

### Getting Data

Using the Client you can query for data from Automatic's REST API. More examples can be found in the demo application which can be [viewed here](http://automaticsharp.azurewebsites.net/).

```c#
var accessToken = await HttpContext.GetTokenAsync("access_token");
var client = new Client(accessToken);

var vehicles = (await client.GetVehiclesAsync()).Results;
```
