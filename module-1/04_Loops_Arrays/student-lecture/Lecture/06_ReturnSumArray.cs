using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureProblem
    {

        /*
        6. How can we write a for loop that sums up the values in this array?
           TOPIC: For Loops
        */
        public int ReturnSumArray()
        {
            int[] arrayToLoopThrough = { 3, 4, 2, 9 };

            int total = 0;
            for (int i = 0; i < arrayToLoopThrough.Length; i++)
            {
                total += arrayToLoopThrough[i];
            }

            return total;
        }
    }
}
