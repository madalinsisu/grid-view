using AutoMapper;
using OperationsApi.Data.Entities;

namespace OperationsApi.Features.Withdrawals.Models
{
    public class WithdrawalProfile : Profile
    {
        public WithdrawalProfile()
        {
            CreateMap<Withdrawal, WithdrawalModel>();
        }
    }
}
