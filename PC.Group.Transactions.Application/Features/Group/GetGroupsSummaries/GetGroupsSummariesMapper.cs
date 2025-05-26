namespace PC.Group.Transactions.Application.Features.Group.GetGroupsSummaries;

using AutoMapper;
using PC.Group.Transactions.Domain.Entities;

public class GetGroupsSummariesMapper : Profile
{
    public GetGroupsSummariesMapper()
    {
        this.CreateMap<Group, GetGroupsSummariesResponse.GroupSummary>()
            .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.MemberCount, opt => opt.MapFrom(src => src.Members.Count));
        this.CreateMap<List<Group>, GetGroupsSummariesResponse>()
            .ForMember(dest => dest.GroupSummaries, opt => opt.MapFrom(src => src));
    }
}