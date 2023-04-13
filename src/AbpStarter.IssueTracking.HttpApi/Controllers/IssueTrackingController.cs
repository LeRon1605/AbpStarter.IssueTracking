using AbpStarter.IssueTracking.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpStarter.IssueTracking.Controllers;


[ApiController]
[Route("/api/[controller]")]
public abstract class IssueTrackingController : AbpControllerBase
{
    protected IssueTrackingController()
    {
        LocalizationResource = typeof(IssueTrackingResource);
    }
}
