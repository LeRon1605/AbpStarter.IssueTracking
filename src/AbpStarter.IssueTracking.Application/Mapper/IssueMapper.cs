using AbpStarter.IssueTracking.Issues;
using AbpStarter.IssueTracking.Issues.Dto.Request;
using AbpStarter.IssueTracking.Issues.Dto.Response;
using AutoMapper;
using System;
using Volo.Abp.AutoMapper;

namespace AbpStarter.IssueTracking.Mapper;

public class IssueMapper: Profile
{
    public IssueMapper()
    {
        CreateMap<IssueCreateDto, Issue>()
            .ConstructUsing(dest => new Issue(Guid.NewGuid()))
            .ForMember(dest => dest.Text, options => options.MapFrom(src => src.Text))
            .ForMember(dest => dest.IsClosed, options => options.MapFrom(src => false))
            .ForMember(dest => dest.CreationTime, options => options.MapFrom(src => DateTime.Now))
            .Ignore(dest => dest.AssignedUserId).Ignore(dest => dest.Labels).Ignore(dest => dest.RepositoryId);

        CreateMap<Issue, IssueDto>()
            .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, options => options.MapFrom(src => src.Text))
            .ForMember(dest => dest.AssignedUserId, options => options.MapFrom(src => src.AssignedUserId))
            .ForMember(dest => dest.CreatorId, options => options.MapFrom(src => src.CreatorId))
            .ForMember(dest => dest.Labels, options => options.MapFrom(src => src.Labels));
    }
}
