using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsApi.Data.Entities
{
    public class OperationType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
