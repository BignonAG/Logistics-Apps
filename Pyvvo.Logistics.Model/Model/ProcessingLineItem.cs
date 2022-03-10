using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class ProcessingLineItem
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long ProcessingId { get; set; }
        [Required] public long OrderLineItemId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int LineNumber { get; set; }
        public double Quantity { get; set; }
        [Required] public Status Status { get; set; }
        [Required] public Processing Processing { get; set; }
        public OrderLineItem OrderLineItem { get; set; }
    }
}
