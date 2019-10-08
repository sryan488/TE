using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataFizzBuzz
    {
        public string ToFizzBuzz(int numberToTest)
        {
            string result = "";

            if (numberToTest < 1 || numberToTest > 100)
            {
                return "";
            }
            if (numberToTest % 15 == 0 || numberToTest.ToString().Contains("3") && numberToTest.ToString().Contains("5"))
            {
                result += "FizzBuzz";
            }
            else if (numberToTest % 3 == 0 || numberToTest.ToString().Contains("3"))
            {
                result += "Fizz";
            }
            else if (numberToTest % 5 == 0 || numberToTest.ToString().Contains("5"))
            {
                result += "Buzz";
            }
            else if (numberToTest % 15 != 0 && numberToTest >= 1 && numberToTest <= 100)
            {
                result += numberToTest;
            }
            return result;
        }


        #region
        //public string ToFizzBuzz(int numberToTest)
        //{
        //  return "1";
        //}
        #endregion

    }
} 
