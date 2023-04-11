using System.Threading.Tasks;

namespace AbpStarter.IssueTracking.Data;

public interface IIssueTrackingDbSchemaMigrator
{
    Task MigrateAsync();
}
