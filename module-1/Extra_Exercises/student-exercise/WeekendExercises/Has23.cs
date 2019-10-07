﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        Given an int array length 2, return true if it contains a 2 or a 3.
        has23([2, 5]) → true
        has23([4, 3]) → true
        has23([4, 5]) → false
        */
        public bool Has23(int[] nums)
        {
            foreach (int i in nums)
            {
                if(i == 2 || i == 3)
                {
                    return true;
                }
            }
                return false;
        }
    }
}
