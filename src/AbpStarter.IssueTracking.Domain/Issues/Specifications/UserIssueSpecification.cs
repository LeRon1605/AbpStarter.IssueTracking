using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace AbpStarter.IssueTracking.Issues.Specifications;

public class UserIssueSpecification : Specification<Issue>
{
    public Guid UserId { get; set; }
    public UserIssueSpecification(Guid userId)
    {
        UserId = userId;
    }
    public override Expression<Func<Issue, bool>> ToExpression()
    {
        return x => x.AssignedUserId == UserId;
    }
}
