# AutomaticSharp
A C# client for Automatic's REST API. 

## Usage

### Authentication

The [Automatic OAuth2 Workflow](https://developer.automatic.com/api-reference/#oauth-workflow) can be completed as follows.

```c#
var code = "users code";
var account = new Account {
    ClientId = "your client id"
    ClientSecret = "your client id"
};

var automaticAuth = new Auth();

var authToken = automaticAuth.GetAccessToken(account, code.Trim());
```

Once you have the authtoken, you can store it in the session or elsewhere for future data queries.

### Getting Data

Using the Client you can query for data from Automatic's REST API.