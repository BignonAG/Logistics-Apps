using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class UserTeam
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long UserId { get; set; }
        [Required] public long TeamId { get; set; }
        [Required] public DateTime CreateDon { get; set; }
        public DateTime UpdateDon { get; set; }
        [Required] public User User { get; set; }
        [Required] public Team Team { get; set; }
    }
}
