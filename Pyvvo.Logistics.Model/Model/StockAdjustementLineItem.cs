using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class StockAdjustementLineItem
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StockAdjustementId { get; set; }
        [Required] public long VariantId { get; set; }
        [Required] public long AgentId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int LineNumber { get; set; }
        public double Quantity { get; set; }
        public bool IsActive { get; set; }
        [Required] public StockAdjustement StockAdjustement { get; set; }
        [Required] public Variant Variant { get; set; }
        public User Agent { get; set; }
        public List<Note> Notes { get; set; }
    }
}
