using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutomaticSharp.Auth;
using AutomaticSharp.Demo.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AutomaticSharp.Demo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if(env.IsDevelopment())
                builder.AddUserSecrets(); // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options => options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);

            // Add framework services.
            services.AddMvc();

            services.AddSingleton(AutoMapperConfig.Configure());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme,
                LoginPath = new PathString("/Home/Index/"),
                LogoutPath = new PathString("/Home/Logout/"),
                AccessDeniedPath = new PathString("/Home/Index/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                SlidingExpiration = true,
                CookieName = "AUTOMATICSHARPDEMO"
            });

            app.UseAutomaticAuthentication(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.ClientId = Configuration["automatic:clientid"];
                options.ClientSecret = Configuration["automatic:clientsecret"];
                options.SaveTokens = true;

                options.AddScope(AutomaticScope.Public);
                options.AddScope(AutomaticScope.UserProfile);
                options.AddScope(AutomaticScope.Location);
                //options.AddScope(AutomaticScope.CurrentLocation);
                options.AddScope(AutomaticScope.VehicleEvents);
                options.AddScope(AutomaticScope.VehicleProfile);
                //options.AddScope(AutomaticScope.VehicleVin);
                options.AddScope(AutomaticScope.Trip);
                options.AddScope(AutomaticScope.Behavior);

                options.Events = new OAuthEvents()
                {
                    OnRemoteFailure = ctx =>
                    {
                        ctx.Response.Redirect("/Error?failureMessage=" + UrlEncoder.Default.Encode(ctx.Failure.Message));
                        ctx.HandleResponse();
                        return Task.FromResult(0);
                    }
                };
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
