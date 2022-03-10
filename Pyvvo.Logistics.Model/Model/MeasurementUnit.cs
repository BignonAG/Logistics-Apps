using System;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class MeasurementUnit
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long MeasurementUnitSystemId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public int Precision { get; set; }
        public string Code { get; set; }
        [Required] public User CreatedBy { get; set; }
        [Required] public MeasurementUnitSystem MeasurementUnitSystem { get; set; }
    }
}