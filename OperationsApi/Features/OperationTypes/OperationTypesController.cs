using AutoMapper;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using OperationsApi.Features.OperationTypes.Models;

namespace OperationsApi.Features.OperationTypes
{
    public class OperationTypesController : BaseController<OperationTypeService, OperationType, OperationTypeModel>
    {
        public OperationTypesController(OperationTypeService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
