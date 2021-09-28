namespace OperationsApi.Data.Entities
{
    public class Withdrawal
    {
        public int ID { get; set; }
        public int OperationID { get; set; }
        public decimal Amount { get; set; }
        public bool WasApprovedByUser2FA { get; set; }
        public string ToAddress { get; set; }
        public Operation Operation { get; set; }
    }
}
