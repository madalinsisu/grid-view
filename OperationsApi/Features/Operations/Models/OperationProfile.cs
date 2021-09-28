using AutoMapper;
using OperationsApi.Data.Entities;

namespace OperationsApi.Features.Operations.Models
{
    public class OperationProfile: Profile
    {
        public OperationProfile()
        {
            CreateMap<Operation, OperationModel>();
        }
    }
}
