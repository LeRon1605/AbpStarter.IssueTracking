using System;
using AbpStarter.IssueTracking.Labels.Dto;

namespace AbpStarter.IssueTracking.Issues.Dto.Response;

public class IssueDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public LabelDto[] Labels { get; set; }
    public Guid RepositoryId { get; set; }
    public Guid? CreatorId { get; set; }
    public Guid? AssignedUserId { get; set; }
}
