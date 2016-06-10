using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

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
            AuthenticationScheme = AutomaticDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/automatic-login");
            AuthorizationEndpoint = AutomaticDefaults.AuthorizationEndpoint;
            TokenEndpoint = AutomaticDefaults.TokenEndpoint;
            UserInformationEndpoint = AutomaticDefaults.UserInformationEndpoint;
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