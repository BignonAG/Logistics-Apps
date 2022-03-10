using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Product
    {

        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long ProductCategoryId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long ImageId { get; set; }
        [Required] public long TaxeId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
        public bool HasMultipleVariant { get; set; }
        public string Unit { get; set; }
        public string ReferenceNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        [Required] public Status Status { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public User CreatedBy { get; set; }
        public Image Image { get; set; }
        public Taxe Taxe { get; set; }
        public List<Option> Options { get; set; }
        public List<Variant> Variants { get; set; }
    }
}
