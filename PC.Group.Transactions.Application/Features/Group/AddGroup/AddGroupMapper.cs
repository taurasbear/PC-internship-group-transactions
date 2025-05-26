namespace PC.Group.Transactions.Application.Features.Group.AddGroup;

using AutoMapper;
using PC.Group.Transactions.Domain.Entities;

public class AddGroupMapper : Profile
{
    public AddGroupMapper()
    {
        this.CreateMap<AddGroupRequest, Group>();
        this.CreateMap<AddGroupRequest, Member>();
    }
}