using Microsoft.EntityFrameworkCore;
using OperationsApi.Data;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using System.Linq;

namespace OperationsApi.Features.Operations
{
    public class OperationService : BaseService<Operation>
    {
        public OperationService(OperationsDBContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Operation> GetAllQueryable()
        {
            return dbContext.Operations
                .Include(x => x.OperationType);
        }
    }
}
