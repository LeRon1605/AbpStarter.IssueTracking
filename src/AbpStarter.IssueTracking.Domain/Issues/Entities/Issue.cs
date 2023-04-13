using AbpStarter.IssueTracking.Buckets;
using AbpStarter.IssueTracking.Enums;
using System;
using System.Collections.Generic;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace AbpStarter.IssueTracking.Issues;

public class Issue: AggregateRoot<Guid>, IHasCreationTime
{
    public string Text { get; set; }
    public bool IsClosed { get; set; }
    public CloseReason? CloseReason { get; set; }
    public Guid RepositoryId { get; set; }
    public Guid? AssignedUserId { get; set; }
    public Guid CreatorId { get; set; }
    public IdentityUser AssignedUser { get; set; }
    public Bucket Bucket { get; set; }
    public ICollection<IssueLabel> Labels { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public IdentityUser CreatedBy { get; set; }
    public DateTime CreationTime { get; set; }

    public Issue(Guid id): base(id)
    {
    }
}
