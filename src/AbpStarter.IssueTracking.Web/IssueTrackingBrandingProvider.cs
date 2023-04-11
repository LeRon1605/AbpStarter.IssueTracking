using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AbpStarter.IssueTracking.Web;

[Dependency(ReplaceServices = true)]
public class IssueTrackingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "IssueTracking";
}
