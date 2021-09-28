using Microsoft.EntityFrameworkCore;
using OperationsApi.Data;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using System.Linq;

namespace OperationsApi.Features.Deposits
{
    public class DepositService: BaseService<Deposit>
    {
        public DepositService(OperationsDBContext dbContext): base (dbContext)
        {
        }

        public override IQueryable<Deposit> GetAllQueryable()
        {
            return dbContext.Deposits
                .Include(x => x.Operation);
        }
    }
}
