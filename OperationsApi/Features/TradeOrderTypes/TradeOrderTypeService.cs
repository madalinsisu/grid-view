using OperationsApi.Data;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;

namespace OperationsApi.Features.TradeOrderTypes
{
    public class TradeOrderTypeService : BaseService<TradeOrderType>
    {
        public TradeOrderTypeService(OperationsDBContext dbContext) : base(dbContext)
        {
        }
    }
}
