using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class InvoiceLineItem
    {
        [Required, Key] public long Id { get; set; }
        public long InvoiceId { get; set; }
        [Required] public long OrderlineItemId { get; set; }
        [Required] public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public int LineNumber { get; set; }
        public Invoice Invoice { get; set; }
        [Required] public OrderLineItem OrderLineItem { get; set; }
    }
}
