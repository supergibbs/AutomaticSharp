using System;
using AutomaticSharp.Auth;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Http;

namespace AutomaticSharp.Demo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			//services.AddAuthentication(options => options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseExceptionHandler("/Home/Error");


            app.UseIISPlatformHandler(); //app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseStaticFiles();

            app.UseCookieAuthentication(options =>
            {
                options.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
              
                options.LoginPath = new PathString("/Home/Index/");
                options.LogoutPath = new PathString("/Home/Logout/");
                options.AccessDeniedPath = new PathString("/Home/Index/");
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.SlidingExpiration = true;
                options.CookieName = "AUTOMATICSHARPDEMO";
            });
        
            app.UseAutomaticAuthentication(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.ClientId = Configuration["automatic:clientid"];
                options.ClientSecret = Configuration["automatic:clientsecret"];
                
                options.AddScope(AutomaticScope.Public);
                options.AddScope(AutomaticScope.UserProfile);
                options.AddScope(AutomaticScope.Location);
                //options.AddScope(AutomaticScope.CurrentLocation);
                options.AddScope(AutomaticScope.VehicleEvents);
                options.AddScope(AutomaticScope.VehicleProfile);
                //options.AddScope(AutomaticScope.VehicleVin);
                options.AddScope(AutomaticScope.Trip);
                options.AddScope(AutomaticScope.Behavior);

                //options.Events = new OAuthEvents()
                //{
                //    OnRemoteFailure = ctx =>

                //    {
                //        ctx.Response.Redirect("/error?FailureMessage=" + UrlEncoder.Default.Encode(ctx.Failure.Message));
                //        ctx.HandleResponse();
                //        return Task.FromResult(0);
                //    }
                //};
            });

            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
