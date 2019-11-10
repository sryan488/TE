using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Validation.Web.Models
{
    public class Registration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }
        public int NumberOfTickets { get; set; }

        public Registration() { }

        public Registration(string firstName, string lastName, string email, string confirmEmail, string password, string confrimPassword, DateTime birthDate, int numberOfTickets)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ConfirmEmail = confirmEmail;
            Password = password;
            ConfirmPassword = confrimPassword;
            BirthDate = birthDate;
            NumberOfTickets = numberOfTickets;
        }
    }
}
