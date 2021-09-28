using AutoMapper;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using OperationsApi.Features.TradeOrderTypes.Models;

namespace OperationsApi.Features.TradeOrderTypes
{
    public class TradeOrderTypesController : BaseController<TradeOrderTypeService, TradeOrderType, TradeOrderTypeModel>
    {
        public TradeOrderTypesController(TradeOrderTypeService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
