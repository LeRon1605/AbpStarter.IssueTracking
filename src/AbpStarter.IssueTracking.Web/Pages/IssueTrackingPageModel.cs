using AbpStarter.IssueTracking.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpStarter.IssueTracking.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class IssueTrackingPageModel : AbpPageModel
{
    protected IssueTrackingPageModel()
    {
        LocalizationResourceType = typeof(IssueTrackingResource);
    }
}
