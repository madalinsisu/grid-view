using AutoMapper;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using OperationsApi.Features.Withdrawals.Models;

namespace OperationsApi.Features.Withdrawals
{
    public class WithdrawalsController : BaseController<WithdrawalService, Withdrawal, WithdrawalModel>
    {
        public WithdrawalsController(WithdrawalService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
