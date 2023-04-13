using System;
using Volo.Abp;

namespace AbpStarter.IssueTracking.Exceptions.Issues;

public class IssueAlreadyExistException: BusinessException 
{
    public IssueAlreadyExistException(string name, Guid repositoryId):
        base(message: $"Issue with name '{name}' is already exist in Repository '{repositoryId}'")
    {

    }
}
