using AbpStarter.IssueTracking.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpStarter.IssueTracking;

[DependsOn(
    typeof(IssueTrackingEntityFrameworkCoreTestModule)
    )]
public class IssueTrackingDomainTestModule : AbpModule
{

}
