using AbpStarter.IssueTracking.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpStarter.IssueTracking.Permissions;

public class IssuePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        // var group = context.AddGroup(IssuePermissions.GroupName);

        // group.AddPermission(IssuePermissions.Read);
        // group.AddPermission(IssuePermissions.Create);
        // group.AddPermission(IssuePermissions.Update);
        // group.AddPermission(IssuePermissions.Delete);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IssueTrackingResource>(name);
    }
}
