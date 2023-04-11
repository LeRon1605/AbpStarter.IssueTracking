using AbpStarter.IssueTracking.Users;
using System;
using Volo.Abp.Domain.Entities;

namespace AbpStarter.IssueTracking.Issues;

public class Comment: Entity<Guid>
{
    public string Text { get; set; }
    public DateTime CreationTime { get; set; }
    public Guid IssueId { get; set; }
    public Guid UserId { get; set;  }
    public Issue Issue { get; set; }
    public User User { get; set; }
}
