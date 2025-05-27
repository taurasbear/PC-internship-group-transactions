namespace PC.Group.Transactions.Application.Features.Member.GetMembersSummaries;

using AutoMapper;
using PC.Group.Transactions.Domain.Entities;

public class GetMembersSummariesMapper : Profile
{
    public GetMembersSummariesMapper()
    {
        this.CreateMap<Member, GetMembersSummariesResponse.MemberSummary>()
            .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));
    }
}