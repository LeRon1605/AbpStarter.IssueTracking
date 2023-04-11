using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace AbpStarter.IssueTracking;

public class IssueTrackingWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<IssueTrackingWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
