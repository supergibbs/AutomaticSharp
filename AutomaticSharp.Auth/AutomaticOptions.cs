using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http;

namespace AutomaticSharp.Auth
{
    /// <summary>
    /// Configuration options for <see cref="AutomaticMiddleware"/>.
    /// </summary>
    public class AutomaticOptions : OAuthOptions
    {
        public AutomaticOptions()
        {
            AuthenticationScheme = AutomaticDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/");
            AuthorizationEndpoint = AutomaticDefaults.AuthorizationEndpoint;
            TokenEndpoint = AutomaticDefaults.TokenEndpoint;
            UserInformationEndpoint = AutomaticDefaults.UserInformationEndpoint;
        }

        public void AddScope(AutomaticScope automaticScope)
        {
            Scope.Add(automaticScope.GetScopeDescription());
        }
    }
}
