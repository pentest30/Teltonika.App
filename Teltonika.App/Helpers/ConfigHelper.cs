using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Teltonika.Core.Data;

namespace Teltonika.App.Helpers
{
    public static class ConfigHelper 
    {
		private static DbContextOptionsBuilder<ApplicationContext> _builder;

		public static DbContextOptionsBuilder<ApplicationContext> DbContextOptionsBuilder
		{
            get
            {
                if (_builder != null)
                    return _builder;
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                _builder = new DbContextOptionsBuilder<ApplicationContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                _builder.UseSqlServer(connectionString);
                return _builder;
            }
            set { _builder = value; }
		}

	}
}
