using System;
using System.Collections.Generic;
using System.Text;

namespace OOPDemo.Models
{
    public class ChildC : ParentB
    {
        public ChildC(string shoeColor, int shoeSize) : base(shoeColor)
        {
            Console.WriteLine($"ChildC constructor: {shoeColor}, {shoeSize}");
        }

//        public override string PublicDerivedStringA => base.PublicDerivedStringA;
        public override string PublicDerivedStringA
        {
            get
            {
                return "ChildC.PublicDerivedStringA";
            }
        }
    }
}
