using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model
{
    public class AccountLogin
    {
        [Key, Required] public long Id { get; set; }
        [Required] public long userId { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required] public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHashAlgorithm { get; set; }
        public string EmailConfirmationToken { get; set; }
        [NotMapped] public string Token { get; set; }
        [Required] public User User { get; set; }
    }
}
