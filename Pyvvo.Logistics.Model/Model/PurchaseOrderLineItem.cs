using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class PurchaseOrderLineItem
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long TaxeId { get; set; }
        [Required] public long VariantId { get; set; }
        [Required] public long PurchaseOrderId { get; set; }
        public int LineNumber { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Taxe Taxe { get; set; }
        [Required] public Variant Variant { get; set; }
        [Required] public PurchaseOrder PurchaseOrder { get; set; }
        public List<Note> Notes { get; set; }
        public List<PurchaseOrderReceiveLineItem> PurchaseOrderReceiveLineItems { get; set; }
        

    }
}
