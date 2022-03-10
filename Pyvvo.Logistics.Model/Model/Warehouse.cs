using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Warehouse
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long AddressId { get; set; }
        [Required] public long ContactId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsExternal { get; set; } 
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public User CreatedBy { get; set; }
        public List<User> Users { get; set; }
        public List<Note> Notes { get; set; }


    }
}
