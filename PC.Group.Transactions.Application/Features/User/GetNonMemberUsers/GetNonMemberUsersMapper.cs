namespace PC.Group.Transactions.Application.Features.User.GetNonMemberUsers;

using AutoMapper;
using PC.Group.Transactions.Domain.Entities;

public class GetNonMemberUsersMapper : Profile
{
    public GetNonMemberUsersMapper()
    {
        this.CreateMap<User, GetNonMemberUsersResponse.NonMember>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        this.CreateMap<List<User>, GetNonMemberUsersResponse>()
            .ForMember(dest => dest.NonMembers, opt => opt.MapFrom(src => src));
    }
}