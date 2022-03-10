using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Supplier
    {

        [Required, Key] public long Id { get; set; }
        [Required] public long AddressId { get; set; }
        [Required] public long ContactId { get; set; }
        [Required] public long RefUserId { get; set; }
        [Required] public long CreatedById { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        [NotMapped] public string CreatedOnLocalTime { get => CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"); }
        public DateTime UpdatedOn { get; set; }
        [NotMapped] public string UpdateOnLocalTime { get => UpdatedOn.ToString("dd/MM/yyyy HH:mm:ss"); }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        [Required] public Address Address { get; set; }
        [Required] public Contact Contact { get; set; }
        [Required] public User RefUser { get; set; }
        [Required] public User CreatedBy { get; set; }
        public List<Note> Notes { get; set; }
        public List<Variant> Variants { get; set; }
    }

}
