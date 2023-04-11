using System;
using Volo.Abp.Domain.Entities;

namespace AbpStarter.IssueTracking.Buckets;

public class Bucket : Entity<Guid>
{
    public string Name { get; set; }
    public Bucket(Guid Id): base(Id)
    {

    }
}
