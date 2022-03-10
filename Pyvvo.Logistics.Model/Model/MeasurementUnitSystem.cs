using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class MeasurementUnitSystem
    {
        [Key, Required] public long Id { get; set; }
        [Required]  public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Name { get; set; }
        public List<MeasurementUnit> MeasurementUnits { get; set; }
    }
}