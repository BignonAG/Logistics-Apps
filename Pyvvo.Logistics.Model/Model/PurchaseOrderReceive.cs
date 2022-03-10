using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class PurchaseOrderReceive
    {

        [Required, Key]  public long Id { get; set; }
        [Required] public long PurchaseOrderId { get; set; }
        [Required] public long AgentId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required] public DateTime ReceivedOn { get; set; }
        public bool IsRestockable { get; set; }
        public bool Complete { get; set; }
        public long ReferenceNumberId { get; set; }
        public string ReferenceNumber { get; set; }
        public string Name { get; set; }
        
        [Required] public PurchaseOrder PurchaseOrder { get; set; }
        [Required] public User Agent { get; set; }
        [Required] public User CreatedBy { get; set; }
        [Required] public Status Status { get; set; }
        public List<Note> Notes { get; set; }
    }
}
