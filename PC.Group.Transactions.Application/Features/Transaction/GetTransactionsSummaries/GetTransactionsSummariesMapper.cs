namespace PC.Group.Transactions.Application.Features.Transaction.GetTransactionsSummaries;

using AutoMapper;
using PC.Group.Transactions.Domain.Entities;

public class GetTransactionsSummariesMapper : Profile
{
    public GetTransactionsSummariesMapper()
    {
        this.CreateMap<Transaction, GetTransactionsSummariesResponse.TransactionSummary>()
            .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Payer, opt => opt.MapFrom(src => src.Payer.User.Username))
            .ForMember(dest => dest.MemberCount, opt => opt.MapFrom(src => src.TransactionPortions.Count))
            .ForMember(dest => dest.SplittingMethod, opt => opt.MapFrom(src => src.Method.ToString()))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Amount));
    }
}