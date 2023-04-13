using AbpStarter.IssueTracking.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using AbpStarter.IssueTracking.Buckets;
using Volo.Abp.EntityFrameworkCore;

namespace AbpStarter.IssueTracking.Repositories;

public class BucketRepository : EfCoreRepository<IssueTrackingDbContext, Bucket, Guid>, IBucketRepository
{
    public BucketRepository(IDbContextProvider<IssueTrackingDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
