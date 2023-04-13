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

    private IssueLabel()
    {
        
    }

    public IssueLabel(Issue issue, Label label)
    {
        Issue = issue;
        IssueId = issue.Id;
        Label = label;
        LabelId = label.Id;
    }

    public IssueLabel(Guid issueId, Guid labelId)
    {
        IssueId = issueId;
        LabelId = labelId;
    }

    public override object[] GetKeys()
    {
        return new Object[] { IssueId, LabelId };
    }
}
