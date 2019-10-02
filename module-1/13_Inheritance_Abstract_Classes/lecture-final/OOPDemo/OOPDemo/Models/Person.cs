using System;
using System.Collections.Generic;
using System.Text;

namespace OOPDemo.Models
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                return (int)((DateTime.Now - BirthDate).TotalDays / 365.25);
            }
        }
        public decimal Income { get; set; }

        public Person(string firstName, string lastName, int birthYear, int birthMonth, int birthDay, decimal income)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = new DateTime(birthYear, birthMonth, birthDay);
            Income = income;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }


    }
}
