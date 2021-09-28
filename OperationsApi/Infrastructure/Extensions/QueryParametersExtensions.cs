using OperationsApi.Infrastructure.Models;

namespace OperationsApi.Infrastructure.Extensions
{
    public static class QueryParametersExtensions
    {
        public static bool IsEmpty(this QueryParameters parameters)
        {
            return parameters?.PageSize > 0 && parameters?.PageNumber > 0;
        }
    }
}
