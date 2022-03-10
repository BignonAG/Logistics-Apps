using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Status
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusCategoryId { get; set; }
        [Required] public DateTime CreateDon { get; set; }
        public DateTime UpdateDon { get; set; }
        public bool IsActive { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        [Required] public StatusCategory StatusCategory { get; set; } // Category type: Order, Shipment ...
    }
}
