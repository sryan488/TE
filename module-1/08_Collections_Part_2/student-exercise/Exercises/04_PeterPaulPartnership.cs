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
         * Modify and return the given Dictionary as follows: if "Peter" has $50 or more, AND "Paul" has $100 or more,
         * then create a new "PeterPaulPartnership" worth a combined contribution of a quarter of each partner's
         * current worth.
         *
         * Note, monetary amounts are specified in cents: penny=1, nickel=5, ... $1=100, ... $10=1000, ...
         * 
         * PeterPaulPartnership({"Peter": 50000, "Paul": 100000}) → {"Peter": 37500, "Paul": 75000, "PeterPaulPartnership": 37500}
         * PeterPaulPartnership({"Peter": 3333, "Paul": 1234567890}) → {"Peter": 3333, "Paul": 1234567890}
         *
         */
        public Dictionary<string, int> PeterPaulPartnership(Dictionary<string, int> peterPaul)
        {
            int petersMoney = peterPaul["Peter"];
            int paulsMoney = peterPaul["Paul"];

            if (paulsMoney >= 10000 && petersMoney >= 5000)
            {
                int petersShare = petersMoney / 4;
                int paulsShare = paulsMoney / 4;
                peterPaul["Paul"] = paulsMoney - paulsShare;
                peterPaul["Peter"] = petersMoney - petersShare;
                peterPaul.Add("PeterPaulPartnership", paulsShare + petersShare);
            }
            return peterPaul;
        }
    }
}
