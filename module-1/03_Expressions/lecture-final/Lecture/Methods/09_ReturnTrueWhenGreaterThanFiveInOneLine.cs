﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {
        /*
         9. How can we rewrite exercise 8 to have only one line of code?
            TOPIC: Boolean Expression & Comparison Operators
        */
        public bool ReturnTrueWhenGreaterThanFiveInOneLine(int number)
        {
            //return (number > 5) ? true : false;
            return (number > 5);
        }

    }
}
