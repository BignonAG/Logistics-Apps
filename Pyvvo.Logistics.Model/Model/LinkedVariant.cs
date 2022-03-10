using System;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class LinkedVariant
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long VariantId { get; set; }
        [Required] public long LinkVariantId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public double Quantity { get; set; }
        public bool IsActive { get; set; }
        [Required] public Variant Variant { get; set; }
        [Required] public Variant LinkVariant { get; set; }
    }
}