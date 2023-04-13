using AbpStarter.IssueTracking.Buckets;
using AbpStarter.IssueTracking.Exceptions.Issues;
using AbpStarter.IssueTracking.Issues.Interfaces;
using AbpStarter.IssueTracking.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace AbpStarter.IssueTracking.Issues.Implementation;

public class IssueManager : DomainService, IIssueManager
{
    private readonly IIssueRepository _issueRepository;
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    public IssueManager(
        IIssueRepository issueRepository,
        IRepository<IdentityUser, Guid> userRepository
    )
    {
        _issueRepository = issueRepository;
        _userRepository = userRepository;
    }

    public async Task<Issue> AssignToUserAsync(Issue issue, IdentityUser user)
    {
        if (await _issueRepository.CountAsync(x => x.AssignedUserId == user.Id && !x.IsClosed) > 3)
        {
            throw new InvalidAssignIssueOperationException(issue.Id, user.Id);   
        }

        issue.AssignedUser = user;
        issue.AssignedUserId = user.Id;
        return issue;
    }

    public async Task<Issue> SetCreator(Issue issue, IdentityUser creator)
    {
        if (await _issueRepository.CountAsync(x => x.CreatorId == creator.Id && !x.IsClosed) > 3)
        {
            throw new InvalidCreateIssueOperationException(issue.Id, creator.Id);
        }
        issue.CreatedBy = creator;
        issue.CreatorId = creator.Id;
        return issue;
    }

    public async Task<Issue> SetLabelAsync(Issue issue, List<Label> labels)
    {
        issue.Labels = labels.Select(x => new IssueLabel(issue, x)).ToList();
        return issue;
    }

    public async Task<Issue> SetState(Issue issue, bool state)
    {
        if (!issue.IsClosed && state)
        {

        }
        issue.IsClosed = state;
        return issue;
    }

    public async Task<Issue> SetTitle(Issue issue, string title)
    {
        if (await _issueRepository.AnyAsync(x => !x.IsClosed && x.RepositoryId == issue.RepositoryId && x.Text == title && x.Id != issue.Id))
        {
            throw new IssueAlreadyExistException(issue.Text, issue.RepositoryId);
        }
        return issue;
    }

    public async Task<Issue> SetToRepositoryAsync(Issue issue, Bucket bucket)
    {
        issue.Bucket = bucket;
        issue.RepositoryId = bucket.Id;
        return issue;
    }
}
