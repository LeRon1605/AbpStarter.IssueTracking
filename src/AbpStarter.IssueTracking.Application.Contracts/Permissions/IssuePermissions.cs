namespace AbpStarter.IssueTracking.Permissions;

public static class IssuePermissions
{
    public const string GroupName = "Issue";

    public const string Create = GroupName + ":Create";
    public const string Update = GroupName + ":Update";
    public const string Read = GroupName + ":Read";
    public const string Delete = GroupName + ":Delete";
}