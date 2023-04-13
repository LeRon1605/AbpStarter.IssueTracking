using AbpStarter.IssueTracking.Issues;
using AbpStarter.IssueTracking.Issues.Dto.Request;
using AbpStarter.IssueTracking.Issues.Dto.Response;
using AbpStarter.IssueTracking.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace AbpStarter.IssueTracking.Controllers;

[RemoteService]
public class IssueController: IssueTrackingController
{
    private readonly IIssueSerice _issueService;
    public IssueController(IIssueSerice issueService)
    {
        _issueService = issueService;
    }

    [HttpGet]
    [Authorize(IssuePermissions.Read)]
    public async Task<List<IssueDto>> GetListAsync()
    {
        List<IssueDto> list = await _issueService.GetListAsync();
        return list;
    }

    [HttpPost]
    [Authorize(IssuePermissions.Create)]
    public async Task<IssueDto> CreateIssueAsync(IssueCreateDto input)
    {
        IssueDto result = await _issueService.CreateAsync(input);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(IssuePermissions.Update)]
    public async Task<IssueDto> UpdateIssueAsync(Guid id, IssueUpdateDto input)
    {
        IssueDto result = await _issueService.UpdateAsync(id, input);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(IssuePermissions.Delete)]
    public async Task<IActionResult> DeleteIssueAsync(Guid id)
    {
        await _issueService.DeleteAsync(id);
        return NoContent();
    }
}
