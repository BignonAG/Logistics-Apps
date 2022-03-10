using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Customer
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long BillingAddressId { get; set; }
        [Required] public long ShippingAddressId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long CurrencyId { get; set; }
        [Required] public long ContactId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        [NotMapped] public string CreatedOnLocalTime { get => CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"); }
        public DateTime UpdatedOn { get; set; }
        [NotMapped] public string UpdateOnLocalTime { get => UpdatedOn.ToString("dd/MM/yyyy HH:mm:ss"); }
        public bool IsActive  { get; set; }
        [Required] public Status Status { get; set; }
        [Required] public Address BillingAddress { get; set; }
        [Required] public Address ShippingAddress { get; set; }
        [Required] public User CreatedBy { get; set; }
        public Currency Currency { get; set; }
        public Contact Contact { get; set; }
        public List<Order> Orders { get; set; }
        public List<Note> Notes { get; set; }
    }
}
