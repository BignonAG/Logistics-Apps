using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Company
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long CurrencyId { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long ContactId { get; set; }
        [Required] public long TenantId { get; set; }
        [Required] public long MeasurementUnitId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        [Required] public Currency Currency { get; set; }
        [Required] public Status Status { get; set; }
        public Contact Contact { get; set; }
        public Tenant Tenant { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
        public List<User> Users { get; set; }
    }
}
