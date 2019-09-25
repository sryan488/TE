using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return true if "bad" appears starting at index 0 or 1 in the string, such as with
         "badxxx" or "xbadxx" but not "xxbadxx". The string may be any length, including 0. Note: use .equals()
         to compare 2 strings.
         HasBad("badxx") → true
         HasBad("xbadxx") → true
         HasBad("xxbadxx") → false
         */
        public bool HasBad(string str)
        {
            int len = str.Length;
            if (len == 3 && str.Equals("bad"))
            {
                return true;
            }
            else if (len >= 4)
            {
                if (str.Substring(0, 3).Equals("bad"))
                {
                    return true;
                }
                return str.Substring(1, 3).Equals("bad");
            }
            else
                return false;

            
        }
    }
}
