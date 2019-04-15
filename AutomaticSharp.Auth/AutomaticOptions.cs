using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AutomaticSharp.Auth
{
    /// <summary>
    /// Configuration options for <see cref="AutomaticMiddleware"/>.
    /// </summary>
    public class AutomaticOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="AutomaticOptions"/>.
        /// </summary>
        public AutomaticOptions()
        {
            ClaimsIssuer = AutomaticDefaults.AuthenticationScheme;
            CallbackPath = new PathString(AutomaticDefaults.CallbackPath);

            AuthorizationEndpoint = AutomaticDefaults.AuthorizationEndpoint;
            TokenEndpoint = AutomaticDefaults.TokenEndpoint;
            UserInformationEndpoint = AutomaticDefaults.UserInformationEndpoint;

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.GivenName, "first_name");
            ClaimActions.MapJsonKey(ClaimTypes.Surname, "last_name");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "username");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            ClaimActions.MapJsonKey(ClaimTypes.Uri, "url");
        }

        /// <summary>
        /// Adds a scope to the login request
        /// </summary>
        /// <param name="automaticScope"></param>
        public void AddScope(AutomaticScope automaticScope)
        {
            Scope.Add(automaticScope.GetScopeDescription());
        }
    }
}