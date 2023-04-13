using System;

namespace AbpStarter.IssueTracking.Issues.Dto.Request;

public class IssueUpdateDto
{
    public string Text { get; set; }
    public bool State { get; set; }
    public Guid? UserId { get; set; }
    public Guid[] Labels { get; set; }
}
