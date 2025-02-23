using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UnderservedCommunitiesLearningPlatform.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Log the connection string to verify it
            Console.WriteLine($"Connection String: {connectionString}");

            optionsBuilder.UseNpgsql(connectionString)
                          .EnableSensitiveDataLogging()
                          .LogTo(Console.WriteLine, LogLevel.Information);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
