using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class RolePermission
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long PermissionId { get; set; }
        [Required] public long RoleId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [Required] public Permission Permission { get; set; }
        [Required] public Role Role { get; set; }

    }
}
