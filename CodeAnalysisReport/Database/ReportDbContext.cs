using CodeAnalysisReport.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CodeAnalysisReport.Database
{
  public class ReportDbContext : DbContext
  {
    public ReportDbContext(DbContextOptions<ReportDbContext> options)
      : base(options) { }

    public DbSet<CodeAnalysis> CodeAnalysis { get; set; }
  }

  public class ReportDbContextFactory : IDesignTimeDbContextFactory<ReportDbContext>
  {
    public ReportDbContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<ReportDbContext>();
      var connectionString = configuration.GetConnectionString("Default");

      var optionsBuilder = new DbContextOptionsBuilder<ReportDbContext>();
      optionsBuilder.UseSqlServer(connectionString);

      return new ReportDbContext(optionsBuilder.Options);
    }
  }
}
