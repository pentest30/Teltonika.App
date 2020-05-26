using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Teltonica.Server;
using Teltonika.App.Hubs;
using Teltonika.Core.Data;
using VueCliMiddleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Teltonika.App.Migration;
using Teltonika.Core.Domain.Users;
using Teltonika.Core.ReverseGeoCoding;
using EFCore.DbContextFactory.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Teeltonika.Application.Service;
using Teltonika.Core;

namespace Teltonika.App
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
            
            services.AddControllersWithViews();

            // Add AddRazorPages if the app uses Razor Pages.
            services.AddRazorPages();

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<UserApp, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationContext>();

            // ===== Add Jwt Authentication ========
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
            // --- end JwT config ---
            services.AddSqlServerDbContextFactory<ApplicationContext>();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
            LoadAssemblies(services);
            services.AddSignalR();
            services.AddSingleton<ReverseGeoCodingService>();
            services.AddSingleton<AsynchronousIoServer>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            //services.AddScoped< INotificationHandler < TLGpsDataEvents >, TeltonikaHandler >();
        }
        private static void SeedInitialData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                #region seed identity data

                var identityContext = scope.ServiceProvider.GetService<ApplicationContext>();
                var identitySeed = new SeedDummyData(identityContext);
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                if (!roleManager.Roles.Any())
                {
                    identitySeed.CreateRolesAsync(scope.ServiceProvider).GetAwaiter().GetResult();
                }
                identitySeed.CreateUsersAsync(scope.ServiceProvider).GetAwaiter().GetResult();


                #endregion
            }
        }
        private static void LoadAssemblies(IServiceCollection services)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var teltonikaServerAssembly =
                Assembly.LoadFrom(string.Concat(path, Path.DirectorySeparatorChar + "Teltonica.Server.dll"));
                var teltonikaAppAssembly =
                Assembly.LoadFrom(string.Concat(path, Path.DirectorySeparatorChar + "Teeltonika.Application.dll"));

            services.AddMediatR(teltonikaAppAssembly);
            //services.AddMediatR(teltonikaHandlerAssembly);
            services.AddMediatR(teltonikaServerAssembly);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapHub<ApplicationHub>("/hub");
                if (env.IsDevelopment())
                {
                    endpoints.MapToVueCliProxy(
                        "{*path}",
                        new SpaOptions { SourcePath = "ClientApp" },
                        npmScript: "serve",
                        regex: "Compiled successfully");
                }

                // Add MapRazorPages if the app uses Razor Pages. Since Endpoint Routing includes support for many frameworks, adding Razor Pages is now opt -in.
                endpoints.MapRazorPages();
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
            //StartServer(app);
            SeedInitialData(app);
        }


        
    }
}
