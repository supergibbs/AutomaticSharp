using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace AutomaticSharp.Auth
{
    public static class AutomaticAuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddAutomaticAuthentication(this AuthenticationBuilder builder)
                 => builder.AddAutomaticAuthentication(AutomaticDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddAutomaticAuthentication(this AuthenticationBuilder builder, Action<AutomaticOptions> configureOptions)
            => builder.AddAutomaticAuthentication(AutomaticDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddAutomaticAuthentication(this AuthenticationBuilder builder, string authenticationScheme, Action<AutomaticOptions> configureOptions)
            => builder.AddAutomaticAuthentication(authenticationScheme, AutomaticDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddAutomaticAuthentication(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<AutomaticOptions> configureOptions)
            => builder.AddOAuth<AutomaticOptions, AutomaticHandler>(authenticationScheme, displayName, configureOptions);
    }
}