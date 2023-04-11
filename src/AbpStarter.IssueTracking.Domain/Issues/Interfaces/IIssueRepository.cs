using System;
using Volo.Abp.Domain.Repositories;

namespace AbpStarter.IssueTracking.Issues.Interfaces;

public interface IIssueRepository: IRepository<Issue, Guid>
{
}
