using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class ReturnLineItem
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long ReturnId { get; set; }
        [Required] public long OrderLineItemId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int LineNumber { get; set; }
        public double Quantity { get; set; }
        public Status Status { get; set; }
        [Required] public Return Return { get; set; }
        [Required] public OrderLineItem OrderLineItem { get; set; }
    }
}
