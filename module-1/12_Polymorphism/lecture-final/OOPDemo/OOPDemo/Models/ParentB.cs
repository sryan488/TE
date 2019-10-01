using System;
using System.Collections.Generic;
using System.Text;

namespace OOPDemo.Models
{
    public class ParentB : GrandparentA
    {
        // Constructor
        public ParentB(string color)
        {
            Console.WriteLine($"ParentB constructor: {color}");
        }

        public override string VirtualMethodA2(string input)
        {
            string s = $"ParentB.VirtualMethodA2:{input}";
            return s;
        }
    }
}
