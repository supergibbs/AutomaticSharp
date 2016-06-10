using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace AutomaticSharp.Auth
{
    public static class AutomaticAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="AutomaticMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Automatic authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseAutomaticAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<AutomaticMiddleware>();
        }

        /// <summary>
        /// Adds the <see cref="AutomaticMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Automatic authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="configureOptions">An action delegate to configure the provided <see cref="AutomaticOptions"/>.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseAutomaticAuthentication(this IApplicationBuilder app, Action<AutomaticOptions> configureOptions)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            if (configureOptions == null)
                throw new ArgumentNullException(nameof(configureOptions));

            var options = new AutomaticOptions();
            configureOptions(options);

            return app.UseMiddleware<AutomaticMiddleware>(Options.Create(options));
        }

        /// <summary>
        /// Adds the <see cref="AutomaticMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Google authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A <see cref="AutomaticOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseAutomaticAuthentication(this IApplicationBuilder app, AutomaticOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<AutomaticMiddleware>(Options.Create(options));
        }
    }
}