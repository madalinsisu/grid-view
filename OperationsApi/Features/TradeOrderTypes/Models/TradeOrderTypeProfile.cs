using AutoMapper;
using OperationsApi.Data.Entities;

namespace OperationsApi.Features.TradeOrderTypes.Models
{
    public class TradeOrderTypeProfile: Profile
    {
        public TradeOrderTypeProfile()
        {
            CreateMap<TradeOrderType, TradeOrderTypeModel>();
                // .ForMember(dest => dest.TradeOrders, src => src.Ignore());
        }
    }
}
