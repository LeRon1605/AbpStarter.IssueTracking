using System;
using Volo.Abp.Domain.Repositories;

namespace AbpStarter.IssueTracking.Buckets;

public interface IBucketRepository: IBasicRepository<Bucket, Guid>
{
}
