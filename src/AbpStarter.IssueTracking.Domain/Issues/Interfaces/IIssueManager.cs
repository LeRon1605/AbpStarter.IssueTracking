using AbpStarter.IssueTracking.Buckets;
using AbpStarter.IssueTracking.Labels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace AbpStarter.IssueTracking.Issues.Interfaces;

public interface IIssueManager: IDomainService
{
    Task<Issue> SetState(Issue issue, bool state);
    Task<Issue> SetTitle(Issue issue, string title);
    Task<Issue> SetCreator(Issue issue, IdentityUser creator);
    Task<Issue> AssignToUserAsync(Issue issue, IdentityUser user);
    Task<Issue> SetToRepositoryAsync(Issue issue, Bucket bucket);
    Task<Issue> SetLabelAsync(Issue issue, List<Label> labels);
}
