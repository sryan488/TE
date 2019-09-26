using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given a List of Integers, and an int value, return true if the int value appears two or more times in
         the list.
         FoundIntTwice( [5, 7, 9, 5, 11], 5 ) -> true
         FoundIntTwice( [6, 8, 10, 11, 13], 8 -> false
         FoundIntTwice( [9, 23, 44, 2, 88, 44], 44) -> true
         */
        public bool FoundIntTwice(List<int> integerList, int intToFind)
        {
            // Save the number of time the passed int value is found
            int count = 0;

            foreach (int i in integerList) // Pass through each element in the list
            {
                if (i == intToFind)
                {
                    count++; // If the integer is found, add 1 to count
                }
            }
            if (count >= 2)
            {
                return true; // integer was found 2 or more times (remembered in 'count')
            }
            return false; // integer was found less than two times (remembered in 'count')
            
        }

    }
}
