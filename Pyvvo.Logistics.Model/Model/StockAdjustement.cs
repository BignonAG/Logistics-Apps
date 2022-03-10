using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class StockAdjustement
    {
        [Required] public long Id { get; set; }
        [Required] public long WarehouseId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long StatusId { get; set; }
        public string Name { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime FinishedOn { get; set; }
        public bool Succeed { get; set; }
        public long ReferenceNumberId { get; set; }
        public string ReferenceNumber { get; set; }
        public Warehouse Warehouse { get; set; }
        public User CreatedBy { get; set; }
        public Status Status { get; set; }
        public List<Note> Notes { get; set; }
        public List<StockAdjustementLineItem> StockAdjustementLineItems { get; set; }

    }
}