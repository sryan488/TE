using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataFizzBuzz
    {
        public string TestToFizzBuzzFor3(int numberToTest)
        {
            string result = "";
            
            if (numberToTest == 1)
            {
                return "1";
            }
            if (numberToTest % 3 == 0)
            {
                result += "Fizz";
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
