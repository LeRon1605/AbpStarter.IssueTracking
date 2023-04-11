using Volo.Abp.Modularity;

namespace AbpStarter.IssueTracking;

[DependsOn(
    typeof(IssueTrackingApplicationModule),
    typeof(IssueTrackingDomainTestModule)
    )]
public class IssueTrackingApplicationTestModule : AbpModule
{

}
