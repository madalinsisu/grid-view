using AutoMapper;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using OperationsApi.Features.Deposits.Models;

namespace OperationsApi.Features.Deposits
{
    public class DepositsController : BaseController<DepositService, Deposit, DepositModel>
    {
        public DepositsController(DepositService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
