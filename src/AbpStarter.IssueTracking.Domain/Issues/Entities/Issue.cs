using AbpStarter.IssueTracking.Buckets;
using AbpStarter.IssueTracking.Enums;
using AbpStarter.IssueTracking.Users;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AbpStarter.IssueTracking.Issues;

public class Issue: AggregateRoot<Guid>
{
    public string Text { get; set; }
    public bool IsClosed { get; set; }
    public CloseReason? CloseReason { get; set; }
    public Guid RepositoryId { get; set; }
    public Guid? AssignedUserId { get; set; }
    public User AssignedUser { get; set; }
    public Bucket Bucket { get; set; }
    public ICollection<IssueLabel> Labels { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
