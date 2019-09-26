using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Person
    { //Default constructor
        public Person() { }

        //Class properties aka permissions
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public int Age { get; set; }

        // Methods
        public string GetFullName()
        {// Return the first and last name of the person witha space
            return ($"{FirstName} {LastName}");
        }
        public bool IsAdult()
        {
            if (Age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
