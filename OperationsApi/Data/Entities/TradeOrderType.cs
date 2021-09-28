using System.Collections.Generic;

namespace OperationsApi.Data.Entities
{
    public class TradeOrderType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<TradeOrder> TradeOrders { get; set; }
    }
}
