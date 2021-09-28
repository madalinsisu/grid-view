namespace OperationsApi.Data.Entities
{
    public class TradeOrder
    {
        public int ID { get; set; }
        public int OperationID { get; set; }
        public decimal Amount { get; set; }
        public int TradeOrderTypeID { get; set; }
        public TradeOrderType TradeOrderType { get; set; }
        public Operation Operation {  get; set; }
    }
}
