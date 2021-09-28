namespace OperationsApi.Data.Entities
{
    public class Deposit
    {
        public int ID { get; set; }
        public int OperationID { get; set; }
        public decimal Amount { get; set; }
        public string FromAddress { get; set; }
        public Operation Operation { get; set; }
    }
}
