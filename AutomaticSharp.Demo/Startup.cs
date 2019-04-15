using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutomaticSharp.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Text.Encodings.Web;
using AutomaticSharp.Demo.Config;

namespace AutomaticSharp.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(co =>
            {
                co.LoginPath = new PathString("/Home/Index/");
                co.LogoutPath = new PathString("/Home/Logout/");
                co.AccessDeniedPath = new PathString("/Home/Index/");
                co.SlidingExpiration = true;
                co.Cookie = new CookieBuilder { Name = "AUTOMATICSHARPDEMO" };
            })
            .AddAutomaticAuthentication(options =>
            {
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(AutoMapperConfig.Configure());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
