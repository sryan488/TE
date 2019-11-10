﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please supply a valid email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "Please enter a password that is more than 8 characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}