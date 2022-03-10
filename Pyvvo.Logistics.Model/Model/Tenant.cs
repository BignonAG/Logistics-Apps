using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class Tenant
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long BillingAddressId { get; set; }
        [Required] public long ShippingAddressId { get; set; }
        [Required] public long CurrencyId { get; set; }
        [Required] public long ContactId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        [Required] public Status Status { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public Currency Currency { get; set; }
        public Contact Contact { get; set; }
        public List<Company> Company { get; set; }

    }
}