using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyvvo.Logistics.Model
{
    public class PaymentTerm
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long CreatedById { get; set; }
        public string Name { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public int DayCount { get; set; }
        [Required] public User CreatedBy { get; set; }
    }
}