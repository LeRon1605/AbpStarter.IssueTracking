using AbpStarter.IssueTracking.Labels;
using System;
using Volo.Abp.Domain.Entities;

namespace AbpStarter.IssueTracking.Issues;

public class IssueLabel : Entity
{
    public Guid IssueId { get; set; }
    public Guid LabelId { get; set; }
    public Issue Issue { get; set; }
    public Label Label { get; set; }

    public override object[] GetKeys()
    {
        return new Object[] { IssueId, LabelId };
    }
}
