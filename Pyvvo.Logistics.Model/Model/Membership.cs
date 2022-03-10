using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Membership
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long UserId { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long RoleId { get; set; }
        [Required] public long CompanyId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public User Users { get; set; }
        [Required] public Status Status { get; set; }
        public Role Role { get; set; }
        public Company Company { get; set; }
    }
}
