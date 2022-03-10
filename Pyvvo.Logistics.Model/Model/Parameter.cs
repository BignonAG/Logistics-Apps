using System;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class Parameter
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long WeightUnitId { get; set; }
        [Required] public long DimensionUnitId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public MeasurementUnit WeightUnit { get; set; }
        public MeasurementUnit DimensionUnit { get; set; }
        public User CreatedBy { get; set; }
    }
}