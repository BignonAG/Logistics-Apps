using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
// A supprimer de la base de donnée et du model
namespace Pyvvo.Logistics.Model
{
    public class Module
    {
        [Required, Key] public long Id { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
    }
}
