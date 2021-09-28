using Microsoft.EntityFrameworkCore;
using OperationsApi.Data.Entities;

namespace OperationsApi.Data
{
    public class OperationsDBContext: DbContext
    {
        public OperationsDBContext(DbContextOptions<OperationsDBContext> options)
            :base(options)
        {
        }

        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<TradeOrder> TradeOrders { get; set; }
        public DbSet<TradeOrderType> TradeOrderTypes { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
    }
}
