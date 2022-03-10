using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Permission
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long OperationId { get; set; }
        [Required] public long DatabaseEntityId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required] public Operation Operation { get; set; }
        [Required] public Module Module { get; set; }
    }
}
