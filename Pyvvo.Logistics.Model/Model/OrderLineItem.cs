using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pyvvo.Logistics.Model
{
    public class OrderLineItem
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long OrderId { get; set; }
        [Required] public long FulfillmentSatusId { get; set; }
        [Required] public long VariantId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int LineNumber { get; set; }
        public string Name { get; set; }
        public bool IsOutOfStock { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public Order Order { get; set; }
        public Status FulfillmentSatus { get; set; }
        public Variant Variant { get; set; }
        public List<InvoiceLineItem> InvoiceLineItems { get; set; }
        public List<RefundLineItem> RefundLineItems { get; set; }
        public List<ShipmentLineItem> ShipmentLineItems { get; set; }
        public List<ProcessingLineItem> ProcessingLineItems { get; set; }
        public List<ReturnLineItem> ReturnLineItems { get; set; }
    }
}