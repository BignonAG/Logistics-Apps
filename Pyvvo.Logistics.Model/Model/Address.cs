using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class Address
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long CreatedById { get; set; }
        public string IntegrationId { get; set; }
        [Required] public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        [Required] public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Province { get; set; }
        public string Zip { get; set; }
        [Required] public string Country { get; set; }
        [Required] public User CreatedBy { get; set; }


    }
}
