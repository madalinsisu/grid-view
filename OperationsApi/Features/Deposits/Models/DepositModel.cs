using OperationsApi.Features.Operations.Models;

namespace OperationsApi.Features.Deposits.Models
{
    public class DepositModel
    {
        public int ID { get; set; }
        public int OperationID { get; set; }
        public decimal Amount { get; set; }
        public string FromAddress { get; set; }
        public OperationModel Operation { get; set; }
    }
}
