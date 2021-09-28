using OperationsApi.Features.Deposits.Models;
using OperationsApi.Features.OperationTypes.Models;
using OperationsApi.Features.TradeOrders.Models;
using OperationsApi.Features.Withdrawals.Models;
using System.Collections.Generic;

namespace OperationsApi.Features.Operations.Models
{
    public class OperationModel
    {
        public int ID { get; set; }
        public int OperationTypeID { get; set; }
        public decimal Amount { get; set; }

        public OperationTypeModel OperationType { get; set; }
        //public List<DepositModel> Deposits { get; set; }
        //public List<TradeOrderModel> TradeOrders { get; set; }
        //public List<WithdrawalModel> Withdrawals { get; set; }
    }
}
