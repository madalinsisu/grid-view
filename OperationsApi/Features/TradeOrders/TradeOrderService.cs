
using Microsoft.EntityFrameworkCore;
using OperationsApi.Data;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using System.Linq;

namespace OperationsApi.Features.TradeOrders
{
    public class TradeOrderService : BaseService<TradeOrder>
    {
        public TradeOrderService(OperationsDBContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<TradeOrder> GetAllQueryable()
        {
            return dbContext.TradeOrders
                .Include(x => x.Operation)
                .Include(x => x.Operation.OperationType)
                .Include(x => x.TradeOrderType);
        }
    }
}
