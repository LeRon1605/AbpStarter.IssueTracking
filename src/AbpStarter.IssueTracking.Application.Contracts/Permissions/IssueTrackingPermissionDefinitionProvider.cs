using AbpStarter.IssueTracking.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpStarter.IssueTracking.Permissions;

public class IssueTrackingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IssueTrackingPermissions.GroupName);

        var issuePermission = myGroup.AddPermission(IssuePermissions.GroupName);

        issuePermission.AddChild(IssuePermissions.Read);
        issuePermission.AddChild(IssuePermissions.Create);
        issuePermission.AddChild(IssuePermissions.Update);
        issuePermission.AddChild(IssuePermissions.Delete);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IssueTrackingResource>(name);
    }
}
