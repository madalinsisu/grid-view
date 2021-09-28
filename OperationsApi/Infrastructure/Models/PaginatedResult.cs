using System.Collections.Generic;

namespace OperationsApi.Infrastructure.Models
{
    public class PaginatedResult<TModel> where TModel : class, new()
    {
        public IEnumerable<TModel> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
