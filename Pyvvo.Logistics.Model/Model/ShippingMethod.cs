using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class ShippingMethod
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long MinParameterId { get; set; }
        [Required] public long MaxparameterId { get; set; }
        [Required] public long CurrencyId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long CarrierServiceId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        [Required] public Status Status { get; set; }
        public Parameter MinParameter { get; set; }
        public Parameter MaxParameter { get; set; }
        public Currency Currency { get; set; }
        public User CreatedBy { get; set; }
        public CarrierService CarrierService { get; set; }

    }
}