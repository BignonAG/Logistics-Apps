using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class PurchaseOrder
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long CurrencyId { get; set; }
        [Required] public long WarehouseId { get; set; }
        [Required] public long ShippingAddressId { get; set; }
        [Required] public long BillingAddressId { get; set; }
        [Required] public long ShippingMethodId { get; set; }
        [Required] public long PaymentTermId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long SupplierId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime TransactedOn { get; set; }
        public DateTime PaidOn { get; set; }
        public bool Succeed { get; set; }
        public long ReferenceNumberId { get; set; }
        public int ReferenceNumber { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required] public Status Status { get; set; }
        [Required] public Currency Currency { get; set; }
        [Required] public Warehouse Warehouse { get; set; }
        [Required] public Address ShippingAddress { get; set; }
        [Required] public Address BillingAddress { get; set; }
        [Required] public ShippingMethod ShippingMethod { get; set; }
        [Required] public PaymentTerm PaymentTerm { get; set; }
        [Required] public User CreatedBy { get; set; }
        [Required] public Supplier Supplier { get; set; }
        public List<Note> Notes { get; set; }
        public List<PurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }
        public List<PurchaseOrderReceive> PurchaseOrderReceives { get; set; }

    }
}
