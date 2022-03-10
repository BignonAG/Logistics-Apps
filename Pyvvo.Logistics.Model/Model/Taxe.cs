using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class Taxe
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public string Name { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public double Rate { get; set; }
        public User CreatedBy { get; set; }
        public List<TaxLineItem> TaxLineItems { get; set; }
    }
}