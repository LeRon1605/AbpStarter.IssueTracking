using System;

namespace AbpStarter.IssueTracking.Issues.Dto.Request;

public class IssueCreateDto
{
    public string Text { get; set; }
    public Guid RepositoryId { get; set; }
    public Guid? UserId { get; set; }
    public Guid[] Labels { get; set; }
}
