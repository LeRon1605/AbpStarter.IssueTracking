using AbpStarter.IssueTracking.Buckets;
using AbpStarter.IssueTracking.Exceptions.Issues;
using AbpStarter.IssueTracking.Issues.Dto.Request;
using AbpStarter.IssueTracking.Issues.Dto.Response;
using AbpStarter.IssueTracking.Issues.Interfaces;
using AbpStarter.IssueTracking.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace AbpStarter.IssueTracking.Issues;

[ExposeServices(typeof(IIssueSerice))]
public class IssueService: IssueTrackingAppService, IIssueSerice
{
    private readonly IIssueRepository _issueRepository;
    private readonly IBucketRepository _bucketRepository;
    private readonly IRepository<Label, Guid> _labelRepository;
    private readonly IIssueManager _issueManager;
    private readonly IdentityUserManager _userManager;

    public IssueService(
        IIssueRepository issueRepository,
        IBucketRepository bucketRepository,
        IIssueManager issueManager,
        IRepository<Label, Guid> labelRepository,
        IdentityUserManager userManager
    )
    {
        _issueRepository = issueRepository;
        _bucketRepository = bucketRepository;
        _issueManager = issueManager;
        _labelRepository = labelRepository;
        _userManager = userManager;
    }

    public async Task<List<IssueDto>> GetListAsync()
    {
        List<Issue> issues = await _issueRepository.GetListWithDetailsAsync();
        return ObjectMapper.Map<List<Issue>, List<IssueDto>>(issues);
    }

    public async Task<IssueDto> CreateAsync(IssueCreateDto request)
    {
        Issue issue = ObjectMapper.Map<IssueCreateDto, Issue>(request);
        await _issueManager.SetTitle(issue, issue.Text);

        Bucket bucket = await _bucketRepository.GetAsync(request.RepositoryId);
        await _issueManager.SetToRepositoryAsync(issue, bucket);

        List<Label> labels = await _labelRepository.GetListAsync(x => request.Labels.Any(id => x.Id == id));
        var nonExistLabels = request.Labels.Except(labels.Select(x => x.Id));
        if (nonExistLabels.Any())
        {
            throw new EntityNotFoundException(typeof(Label), nonExistLabels.ElementAt(0));
        }    
        await _issueManager.SetLabelAsync(issue, labels);

        if (request.UserId.HasValue)
        {
            IdentityUser user = await _userManager.GetByIdAsync(request.UserId.Value);
            await _issueManager.AssignToUserAsync(issue, user);
        }

        IdentityUser creator = await _userManager.GetByIdAsync(CurrentUser.Id.Value);
        await _issueManager.SetCreator(issue, creator);

        await _issueRepository.InsertAsync(issue);
        await UnitOfWorkManager.Current.SaveChangesAsync();
        return ObjectMapper.Map<Issue, IssueDto>(issue);
    }

    public async Task<IssueDto> UpdateAsync(Guid id, IssueUpdateDto request)
    {
        Issue issue = await _issueRepository.GetWithDetailsAsync(id);

        await _issueManager.SetState(issue, request.State);

        await _issueManager.SetTitle(issue, request.Text);

        List<Label> labels = await _labelRepository.GetListAsync(x => request.Labels.Any(id => x.Id == id));
        var nonExistLabels = request.Labels.Except(labels.Select(x => x.Id));
        if (nonExistLabels.Any())
        {
            throw new EntityNotFoundException(typeof(Label), nonExistLabels.ElementAt(0));
        }    
        await _issueManager.SetLabelAsync(issue, labels);

        if (request.UserId.HasValue && request.UserId != issue.AssignedUserId)
        {
            IdentityUser user = await _userManager.GetByIdAsync(request.UserId.Value);
            await _issueManager.AssignToUserAsync(issue, user);
        }

        await _issueRepository.UpdateAsync(issue);
        await UnitOfWorkManager.Current.SaveChangesAsync();
        return ObjectMapper.Map<Issue, IssueDto>(issue);
    }

    public async Task DeleteAsync(Guid id)
    {
        Issue issue = await _issueRepository.GetAsync(id);
        if (CurrentUser.Id != issue.CreatorId)
        {
            throw new InvalidDeleteIssueOperationException(id);
        }

        await _issueRepository.DeleteAsync(issue);
        await UnitOfWorkManager.Current.SaveChangesAsync();
    }
}
