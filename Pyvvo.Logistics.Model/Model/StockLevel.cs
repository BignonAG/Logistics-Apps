using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class StockLevel
    {
        [Required, Key]  public long Id { get; set; }
        [Required] public long LocationyId { get; set; }
        public double Quantity { get; set; } 
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Warehouse Location { get; set; }
    }
}
