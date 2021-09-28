using System.Collections.Generic;

namespace OperationsApi.Data.Entities
{
    public class OperationType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
