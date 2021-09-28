using OperationsApi.Features.Operations.Models;
using OperationsApi.Features.TradeOrderTypes.Models;

namespace OperationsApi.Features.TradeOrders.Models
{
    public class TradeOrderModel
    {
        public int ID { get; set; }
        public int OperationID { get; set; }
        public decimal Amount { get; set; }
        public int TradeOrderTypeID { get; set; }
        public TradeOrderTypeModel TradeOrderType { get; set; }
        public OperationModel Operation { get; set; }
    }
}
