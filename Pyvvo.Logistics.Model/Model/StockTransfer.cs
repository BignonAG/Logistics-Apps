using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class StockTransfer
    {

        [Required, Key] public long Id { get; set; }
        [Required] public long OldWarehouseId { get; set; }
        [Required] public long NewWarehouseId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long StatusId { get; set; }
        public string Name { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime TransactedOn { get; set; } // The Date where the stockTransfer was carried out
        public bool Succeed { get; set; }
        public long ReferenceNumberId { get; set; }
        public string ReferencedNumber { get; set; }
        public Warehouse OldWarehouse { get; set; }
        public Warehouse NewWarehouse { get; set; }
        public User CreatedBy { get; set; }
        public Status Status { get; set; }
        public List<StockTransferLineItem> StockTransferLineItems { get; set; }
        public List<Note> Notes { get; set; }
    }
}
