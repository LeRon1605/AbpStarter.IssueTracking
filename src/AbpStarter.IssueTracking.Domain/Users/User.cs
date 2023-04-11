using AbpStarter.IssueTracking.Issues;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AbpStarter.IssueTracking.Users;

public class User: Entity<Guid>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Issue> Issues { get; set; }

    public User(Guid Id): base(Id)
    {

    }
}
