using AutoMapper;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using OperationsApi.Features.TradeOrders.Models;

namespace OperationsApi.Features.TradeOrders
{
    public class TradeOrdersController : BaseController<TradeOrderService, TradeOrder, TradeOrderModel>
    {
        public TradeOrdersController(TradeOrderService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
