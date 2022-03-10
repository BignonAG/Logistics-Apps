using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pyvvo.Logistics.Model
{
    public class Contact
    {
        [Required, Key] public long Id { get; set; }
        [Required] public long StatusId { get; set; }
        public long ImageId { get; set; }       
        [Required] public DateTime CreateDon { get; set; }
        public DateTime UpdateDon { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required] public string Email { get; set; }
        public string Password { get; set; }
        public string VerifiedEmail { get; set; }
        public bool AcceptTermsOfService { get; set; }
        public string Language { get; set; }
        public string Timezone { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Viadeo { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        [Required] public Status Status { get; set; }
        public Image Image { get; set; }

    }
}