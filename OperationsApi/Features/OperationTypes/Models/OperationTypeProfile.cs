using AutoMapper;
using OperationsApi.Data.Entities;

namespace OperationsApi.Features.OperationTypes.Models
{
    public class OperationTypeProfile: Profile
    {
        public OperationTypeProfile()
        {
            CreateMap<OperationType, OperationTypeModel>();
                // .ForMember(dest => dest.Operations, src => src.Ignore());
        }
    }
}
