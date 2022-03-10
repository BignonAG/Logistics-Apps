using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class Invoice
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long PaymentTermId { get; set; }
        [Required] public long OrderId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public string ReferenceNumber { get; set; }
        public long ReferenceNumberId { get; set; }
        public string Description { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
        public Order Order { get; set; }
        public User CreatedBy { get; set; }
        public List<InvoiceLineItem> InvoiceLineItems { get; set; }
    }
}
