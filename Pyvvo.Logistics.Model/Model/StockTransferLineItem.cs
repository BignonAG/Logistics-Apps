using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class StockTransferLineItem
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StockTransferId { get; set; }
        [Required] public long VariantId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int LineNumber { get; set; }
        public double Quantity { get; set; }
        public bool IsActive { get; set; }
        [Required] public StockTransfer StockTransfer { get; set; }
        [Required] public Variant Variant { get; set; }
        public List<Note> Notes { get; set; }
    }

}
