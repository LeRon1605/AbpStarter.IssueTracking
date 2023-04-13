using AbpStarter.IssueTracking.DomainProperty;
using AbpStarter.IssueTracking.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace AbpStarter.IssueTracking.EntityFrameworkCore;

public static class IssueTrackingEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        IssueTrackingGlobalFeatureConfigurator.Configure();
        IssueTrackingModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            //ObjectExtensionManager.Instance
            //    .MapEfCoreProperty<IdentityUser, ICollection<Comment>>(
            //            IdentityUserExtensionProperty.Comments,
            //            (entityBuilder, propertyBuilder) =>
            //            {

            //            }
            //     )
            //    .MapEfCoreProperty<IdentityUser, ICollection<Issue>>(
            //            IdentityUserExtensionProperty.CreatedIssues,
            //            (entityBuilder, propertyBuilder) =>
            //            {

            //            }
            //    )
            //    .MapEfCoreProperty<IdentityUser, ICollection<Issue>>(
            //            IdentityUserExtensionProperty.AssignedIssues,
            //            (entityBuilder, propertyBuilder) =>
            //            {

            //            }
            //    );
        });
    }
}
