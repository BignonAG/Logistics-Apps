using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Order
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long PayementStatusId { get; set; }
        [Required] public long FulfillmentStatusId { get; set; }
        [Required] public long BillingAddressId { get; set; }
        [Required] public long ShippingAddressId { get; set; }
        [Required] public long TaxeId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long CurrencyId { get; set; }
        [Required] public long CustomerId { get; set; }
        [Required] public long WarehouseId { get; set; }
        [Required] public long ShippingMethodId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        [NotMapped] public string CreatedOnLocalTime { get => CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"); }
        public DateTime UpdatedOn { get; set; }
        [NotMapped] public string UpdateOnLocalTime { get => UpdatedOn.ToString("dd/MM/yyyy HH:mm:ss"); }
        [NotMapped] public string Qte { get; set; }
        public bool IsActive { get; set; }
        public DateTime? PaidOn { get; set; }
        public DateTime? CancelOn { get; set; }
        public string ReferenceNumber { get; set; }
        public long ReferenceNumberId { get; set; }
        public string CurrencyCode { get; set; }
        public double SubtotalBeforeTax { get; set; }
        public double TotalPrice { get; set; }
        public double TotalTax { get; set; }
        public string DiscountType { get; set; } 
        public string DiscountValue { get; set; }
        public Status PayementStatus { get; set; }
        [Required] public Status Status { get; set; }
        [Required] public Status FulfillmentStatus { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public Taxe Taxe { get; set; }
        public User CreatedBy { get; set; }
        [Required] public Currency Currency { get; set; }
        [Required] public Customer Customer { get; set; }
        [Required] public Warehouse Warehouse { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public List<Shipment> Shippings { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Processing> Processings { get; set; }
        public List<Return> Returns { get; set; }
        public List<Refund> Refunds { get; set; }
        public List<OrderLineItem> OrderLineItems { get; set; }
    }
}
