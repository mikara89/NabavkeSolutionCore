
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NabavkeSolutionCore.Data.Persistence;
using AutoMapper;
using NabavkeSolutionCore.Models.Helpers;
using NabavkeSolutionCore.Data.Models.Code_First_DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace NabavkeSolutionCore
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

            services.AddAutoMapper();
            services.AddTransient<INotificationHandler, NotificationHandler>();
            services.AddDbContext<NabavkeSolutionCoreDbContext>(
                options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Default")
                    )
                 );

            services.Configure<OneSignalAPIKey>(Configuration.GetSection("OneSignalAPIKey"));
            services.Configure<ConfigIssuer>(Configuration.GetSection("ConfigIssuer"));

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireNonAlphanumeric = true;
                // User settings
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<NabavkeSolutionCoreDbContext>();

            services.AddAuthorization(options => {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
  
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            ILoggerFactory logger,
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            logger.AddConsole(Configuration.GetSection("Logging"));
            logger.AddDebug();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
