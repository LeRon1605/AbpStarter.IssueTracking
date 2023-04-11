using AbpStarter.IssueTracking.Issues;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AbpStarter.IssueTracking.Labels;

public class Label: Entity<Guid>
{
    public string Text { get; set; }
    public string Color { get; set; }
    public ICollection<IssueLabel> Issues { get; set; }
}
