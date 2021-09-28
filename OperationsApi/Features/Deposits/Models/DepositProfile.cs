using AutoMapper;
using OperationsApi.Data.Entities;

namespace OperationsApi.Features.Deposits.Models
{
    public class DepositProfile: Profile
    {
        public DepositProfile()
        {
            CreateMap<Deposit, DepositModel>();
        }
    }
}
