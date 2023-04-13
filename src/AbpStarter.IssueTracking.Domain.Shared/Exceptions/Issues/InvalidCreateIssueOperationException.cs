using System;
using Volo.Abp;

namespace AbpStarter.IssueTracking.Exceptions.Issues;

public class InvalidCreateIssueOperationException : Exception, IBusinessException
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public InvalidCreateIssueOperationException(Guid Id, Guid UserId)
            : base($"Can not create new issue '{Id}' if user '{UserId} has already created more than 3 opened issues'")
    {

    }
}
