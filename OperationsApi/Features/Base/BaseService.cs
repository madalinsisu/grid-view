using Microsoft.EntityFrameworkCore;
using OperationsApi.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OperationsApi.Features.Base
{
    public abstract class BaseService<TEntity> where TEntity : class, new()
    {
        protected readonly OperationsDBContext dbContext;

        public BaseService(OperationsDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual IQueryable<TEntity> GetAllQueryable()
        {
            return dbContext.Set<TEntity>();
        }
    }
}
