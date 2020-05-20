using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Teltonica.Server;
using Teltonika.Core;
using Teltonika.Core.ReverseGeoCoding;

namespace TeltonikaDokerListener
{
    public static class ServiceAppExtensions
    {
        public static IWebHostBuilder UseServiceBaseLifetime(this IWebHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(GetAppSettings());
                services.AddSingleton<ILogger, Logger<dynamic>>();
            });
        }

        public static AppSettings GetAppSettings()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var settings = configuration.GetSection("AppSettings").Get<AppSettings>();
            return settings;
        }


    }
}