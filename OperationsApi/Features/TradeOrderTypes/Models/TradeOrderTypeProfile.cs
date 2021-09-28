using AutoMapper;
using OperationsApi.Data.Entities;

namespace OperationsApi.Features.TradeOrderTypes.Models
{
    public class TradeOrderTypeProfile: Profile
    {
        public TradeOrderTypeProfile()
        {
            CreateMap<TradeOrderType, TradeOrderTypeModel>();
        }
    }
}
