using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Refund
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long OrderId { get; set; }
        [Required] public long CreatedById { get; set; }
        public string ReferenceNumber { get; set; }
        public long ReferenceNumberId { get; set; }
        public long TotalPrice { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime RefundedOn { get; set; } 
        public bool IsActive { get; set; }
        [Required] public Status Status { get; set; }
        [Required] public Order Order { get; set; }
        [Required] public User CreatedBy { get; set; }
        [Required] public List<RefundLineItem> RefundLineItems { get; set; }

    }
}
