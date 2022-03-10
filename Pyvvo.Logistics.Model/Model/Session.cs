using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Session
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long UserId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime ConnectedOn { get; set; }
        public string UserAgent { get; set; }
        public string Token { get; set; }
        [Required] public User User { get; set; } //Add Mermbership CreatedBy
    }
}
