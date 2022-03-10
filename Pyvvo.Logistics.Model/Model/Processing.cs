using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Processing
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long OrderId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long AgentId { get; set; }
        public long ReferenceNumberId { get; set; }
        public string ReferenceNumber { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool SendUpdate { get; set; }
        [Required] public Status Status { get; set; }
        [Required] public Order Order { get; set; }
        [Required] public User CreatedBy { get; set; }
        public User Agent { get; set; }
        public List<ProcessingLineItem> ProcessingLineItems { get; set; }
        public List<Note> Notes { get; set; }
        
    }
}
