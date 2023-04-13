using System;
using Volo.Abp;

namespace AbpStarter.IssueTracking.Exceptions.Issues;

public class InvalidDeleteIssueOperationException: Exception, IBusinessException
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public InvalidDeleteIssueOperationException(Guid Id)
            : base($"You are not allow to delete issue with id '{Id}'")
    {

    }
}

