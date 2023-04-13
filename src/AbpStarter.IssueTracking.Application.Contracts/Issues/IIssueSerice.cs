using AbpStarter.IssueTracking.Issues.Dto.Request;
using AbpStarter.IssueTracking.Issues.Dto.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpStarter.IssueTracking.Issues;

public interface IIssueSerice: IApplicationService
{
    Task<List<IssueDto>> GetListAsync();
    Task<IssueDto> CreateAsync(IssueCreateDto request);
    Task<IssueDto> UpdateAsync(Guid id, IssueUpdateDto request);
    Task DeleteAsync(Guid id);
}