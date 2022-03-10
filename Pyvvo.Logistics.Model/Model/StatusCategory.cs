using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
  
  // A supprimer du model et de la base de données
namespace Pyvvo.Logistics.Model
{
    public class StatusCategory
    {
        [Required, Key] public long Id { get; set; }
        [Required] public DateTime CreateDon { get; set; }
        public DateTime UpdateDon { get; set; }
        [Required] public string Name { get; set; }
    }
}
