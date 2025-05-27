namespace PC.Group.Transactions.Application.Features.Member.AddMember;

using AutoMapper;
using PC.Group.Transactions.Domain.Entities;

public class AddMemberMapper : Profile
{
    public AddMemberMapper()
    {
        this.CreateMap<AddMemberRequest, Member>();
    }
}