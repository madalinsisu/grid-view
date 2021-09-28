using OperationsApi.Features.Operations.Models;

namespace OperationsApi.Features.Withdrawals.Models
{
    public class WithdrawalModel
    {
        public int ID { get; set; }
        public int OperationID { get; set; }
        public decimal Amount { get; set; }
        public bool WasApprovedByUser2FA { get; set; }
        public string ToAddress { get; set; }
        public OperationModel Operation { get; set; }
    }
}
