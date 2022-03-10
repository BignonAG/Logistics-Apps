using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class DatabaseEntity
    {
        [Required, Key] public long Id { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        [Required]public DateTime UpdatedOn { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
