using System;
using System.Collections.Generic;
using System.Text;

namespace States.Model
{
    class State
    {
        public string StateCode { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string LargestCity { get; set; }

        public State(string stateCode, string name, string capital, string largestCity)
        {
            this.StateCode = stateCode;
            this.Name = name;
            this.Capital = capital;
            this.LargestCity = largestCity;
        }

    }
}
