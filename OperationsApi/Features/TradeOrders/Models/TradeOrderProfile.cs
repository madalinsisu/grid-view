using AutoMapper;
using OperationsApi.Data.Entities;

namespace OperationsApi.Features.TradeOrders.Models
{
    public class TradeOrderProfile : Profile
    {
        public TradeOrderProfile()
        {
            CreateMap<TradeOrder, TradeOrderModel>();
        }
    }
}
