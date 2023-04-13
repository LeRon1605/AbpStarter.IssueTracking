using System;
using Volo.Abp;

namespace AbpStarter.IssueTracking.Exceptions.Issues;

public class InvalidAssignIssueOperationException: Exception, IBusinessException
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public InvalidAssignIssueOperationException(Guid Id, Guid UserId) 
            : base($"Can not assign issue '{Id}' to user '{UserId} has already more than 3 opened issues'")
    {

    }
}
