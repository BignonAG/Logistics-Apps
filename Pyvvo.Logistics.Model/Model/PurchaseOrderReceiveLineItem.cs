using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class PurchaseOrderReceiveLineItem
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long PurchaseOrderReceiveId { get; set; }
        [Required] public long PurchaseOrderLineItemId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int LineNumber { get; set; }
        public double Quantity { get; set; }
        public List<Note> Notes { get; set; }
        [Required] public PurchaseOrderReceive PurchaseOrderReceive { get; set; }
        [Required] public PurchaseOrderLineItem PurchaseOrderLineItem { get; set; }
    }
}
