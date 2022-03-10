using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Shipment
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long ShippingMethodId { get; set; }
        [Required] public long OrderId { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long AgentId { get; set; }
        [Required] public long CreatedById { get; set; }
        public long ReferenceNumberId { get; set; }
        public string ReferenceNumber { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime ShippedOn { get; set; }
        public DateTime DeliveredOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool SendUpdate { get; set; }
        public string TrackNumber { get; set; }
        public string TrackUrl { get; set; }
        public string ShippingCharge { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        [Required] public Order Order { get; set; }
        [Required] public Status Status { get; set; }
        public User Agent { get; set; }
        [Required] public User CreatedBy { get; set; }
        public List<Note> Notes { get; set; }
        public List<ShipmentLineItem> ShipmentLineItems { get; set; }

    }
}
