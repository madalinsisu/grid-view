using AutoMapper;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;
using OperationsApi.Features.Operations.Models;

namespace OperationsApi.Features.Operations
{
    public class OperationsController : BaseController<OperationService, Operation, OperationModel>
    {
        public OperationsController(OperationService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
