using System;

namespace AbpStarter.IssueTracking.Labels.Dto;

public class LabelDto
{
    public Guid Id { get; set; }
    public string Text { get;set; }
    public string Color { get; set; }
}