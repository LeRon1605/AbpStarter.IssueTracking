using AbpStarter.IssueTracking.Issues;
using AbpStarter.IssueTracking.Labels;
using AbpStarter.IssueTracking.Labels.Dto;
using AutoMapper;

namespace AbpStarter.IssueTracking.Mapper;

public class LabelMapper: Profile
{
    public LabelMapper()
    {
        CreateMap<IssueLabel, LabelDto>()
            .ForMember(dest => dest.Id, options => options.MapFrom(src => src.LabelId))
            .ForMember(dest => dest.Text, options => options.MapFrom(src => src.Label.Text))
            .ForMember(dest => dest.Color, options => options.MapFrom(src => src.Label.Color));
        CreateMap<Label, LabelDto>();
    }
}