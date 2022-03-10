using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class TaxLineItem
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long TaxeId { get; set; }
        public string Name { get; set; }
        public int LineNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Rate { get; set; }
        public Taxe Taxe { get; set; }
    }
}
