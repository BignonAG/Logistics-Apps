using System;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class Option
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long VariantId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Name { get; set; }
        public Variant Variant { get; set; }
    }
}