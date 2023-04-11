using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpStarter.IssueTracking.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class IssueTrackingDbContextFactory : IDesignTimeDbContextFactory<IssueTrackingDbContext>
{
    public IssueTrackingDbContext CreateDbContext(string[] args)
    {
        IssueTrackingEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<IssueTrackingDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new IssueTrackingDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpStarter.IssueTracking.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
