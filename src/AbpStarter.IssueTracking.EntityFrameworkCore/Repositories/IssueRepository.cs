using AbpStarter.IssueTracking.EntityFrameworkCore;
using AbpStarter.IssueTracking.Issues;
using AbpStarter.IssueTracking.Issues.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpStarter.IssueTracking.Repositories;

public class IssueRepository : EfCoreRepository<IssueTrackingDbContext, Issue, Guid>, IIssueRepository
{
    public IssueRepository(IDbContextProvider<IssueTrackingDbContext> dbContextProvider) : base(dbContextProvider)
    {
        
    }

    public async Task<List<Issue>> GetListWithDetailsAsync(Expression<Func<Issue, bool>> expression = null)
    {
        var context = await GetDbContextAsync();
        var queryable = context.Issues.Include(x => x.Bucket).Include(x => x.Labels).ThenInclude(x => x.Label);
        if (expression != null)
        {
            return await queryable.Where(expression).ToListAsync();
        }
        return await queryable.ToListAsync();
    }

    public async Task<Issue> GetWithDetailsAsync(Guid id)
    {
        var context = await GetDbContextAsync();
        return await context.Issues.Include(x => x.Bucket)
                                   .Include(x => x.Labels)
                                   .ThenInclude(x => x.Label)
                                   .FirstOrDefaultAsync(x => x.Id == id);

    }
}
