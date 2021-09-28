using System.Collections.Generic;

namespace OperationsApi.Data.Entities
{
    public class Operation
    {
        public int ID { get; set; }
        public int OperationTypeID { get; set; }
        public decimal Amount { get; set; }

        public OperationType OperationType { get; set; }
        public ICollection<Deposit> Deposits { get; set; }
        public ICollection<TradeOrder> TradeOrders { get; set; }
        public ICollection<Withdrawal> Withdrawals { get; set; }
    }
}
