using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpStarter.IssueTracking.Pages;

public class Index_Tests : IssueTrackingWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
