using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpStarter.IssueTracking.Issues.Interfaces;

public interface IIssueRepository: IRepository<Issue, Guid>
{
    Task<Issue> GetWithDetailsAsync(Guid id);
    Task<List<Issue>> GetListWithDetailsAsync(Expression<Func<Issue, bool>> expression = null);
}
