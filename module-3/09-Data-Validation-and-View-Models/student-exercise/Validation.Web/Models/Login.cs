using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Validation.Web.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please supply a valid email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Login() { }

        public Login(string email,string password)
        {
            Email = email;
            Password = password;
        }
    }
}
