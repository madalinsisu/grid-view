using OperationsApi.Data;
using OperationsApi.Data.Entities;
using OperationsApi.Features.Base;

namespace OperationsApi.Features.OperationTypes
{
    public class OperationTypeService : BaseService<OperationType>
    {
        public OperationTypeService(OperationsDBContext dbContext) : base(dbContext)
        {
        }
    }
}
