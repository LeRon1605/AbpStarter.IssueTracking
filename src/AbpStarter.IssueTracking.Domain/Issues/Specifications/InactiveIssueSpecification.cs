using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace AbpStarter.IssueTracking.Issues.Specifications;

public class InactiveIssueSpecification : Specification<Issue>
{
    public override Expression<Func<Issue, bool>> ToExpression()
    {
        return x => !x.IsClosed;
    }
}
