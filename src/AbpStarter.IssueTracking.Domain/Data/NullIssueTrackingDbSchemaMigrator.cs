using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpStarter.IssueTracking.Data;

/* This is used if database provider does't define
 * IIssueTrackingDbSchemaMigrator implementation.
 */
public class NullIssueTrackingDbSchemaMigrator : IIssueTrackingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
