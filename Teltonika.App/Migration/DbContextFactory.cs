using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Teltonika.Core.Data;

namespace Teltonika.App.Migration
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Trace.WriteLine(connectionString);
            dbContextBuilder.UseSqlServer(connectionString);

            return new ApplicationContext(dbContextBuilder.Options);
        }
    
    }
}
