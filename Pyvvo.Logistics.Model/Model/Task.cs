using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Task
    {

        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public long AgentId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required] public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string Priority { get; set; }
        public string Content { get; set; }
        public Status Status { get; set; }
        [Required] public User CreatedBy { get; set; }
        [Required] public User Agent { get; set; }
        public List<Note> Notes { get; set; }

    }
}
