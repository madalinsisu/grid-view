using Microsoft.EntityFrameworkCore;
using OperationsApi.Data;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using System.Linq;

namespace OperationsApi.Features.Withdrawals
{
    public class WithdrawalService : BaseService<Withdrawal>
    {
        public WithdrawalService(OperationsDBContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Withdrawal> GetAllQueryable()
        {
            return dbContext.Withdrawals    
                .Include(x => x.Operation)
                .Include(x => x.Operation.OperationType);
        }
    }
}
