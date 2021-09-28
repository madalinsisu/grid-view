using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsApi.Data.Entities
{
    public class TradeOrderType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<TradeOrder> TradeOrders { get; set; }
    }
}
