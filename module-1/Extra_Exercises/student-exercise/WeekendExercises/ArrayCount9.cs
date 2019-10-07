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
          Given an array of ints, return the number of 9's in the array.
          arrayCount9([1, 2, 9]) → 1
          arrayCount9([1, 9, 9]) → 2
          arrayCount9([1, 9, 9, 3, 9]) → 3
          */
        public int ArrayCount9(int[] nums)
        {
            int count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 9)
                {
                    count = count + 1;
                }
            }
            return count;

        }
    }
}
