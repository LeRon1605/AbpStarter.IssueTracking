using AbpStarter.IssueTracking.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpStarter.IssueTracking.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IssueTrackingController : AbpControllerBase
{
    protected IssueTrackingController()
    {
        LocalizationResource = typeof(IssueTrackingResource);
    }
}
