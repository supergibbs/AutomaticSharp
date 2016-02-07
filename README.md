[![Build status](https://ci.appveyor.com/api/projects/status/nt6f9847b1mys8xx/branch/master?svg=true)](https://ci.appveyor.com/project/supergibbs/automaticsharp/branch/master)
[![NuGet](https://img.shields.io/nuget/v/AutomaticSharp.svg)](https://www.nuget.org/packages/AutomaticSharp)
# AutomaticSharp 
A C# client for Automatic's REST API. 

## Usage

### Authentication

The [Automatic OAuth2 Workflow](https://developer.automatic.com/api-reference/#oauth-workflow) can be completed using the `Microsoft.AspNet.Authentication.OAuth` framwork.

In a modern webapp you can add this to your `startup.cs`
```c#
app.UseAutomaticAuthentication(options =>
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

Using the Client you can query for data from Automatic's REST API. More examples to come.

```c#
var client = new Client(access_token);
var vehicles = (await client.GetVehiclesAsync()).Results;
```