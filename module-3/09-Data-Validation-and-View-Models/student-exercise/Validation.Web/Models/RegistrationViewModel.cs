using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Web.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please supply a valid email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please supply a valid email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [DataType(DataType.EmailAddress)]
        [Compare(nameof(Email), ErrorMessage = "Please match emails")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "Please enter a password that is more than 8 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [Compare(nameof(Password), ErrorMessage = "Please match passwords")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please enter a number of tickets")]
        [Range(1, 10)]
        public int NumberOfTickets { get; set; }

    }
}