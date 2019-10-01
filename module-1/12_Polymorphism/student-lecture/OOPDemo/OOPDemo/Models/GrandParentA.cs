using System;
using System.Collections.Generic;
using System.Text;

namespace OOPDemo.Models
{
    public class GrandparentA
    {
        // Private and protected fields
        private string privateStringA = "";
        protected string protectedStringA = "";

        // Public and protected properties
        public string PublicGetProtectedSetStringA { get; protected set; } = "GrandparentA.PublicGetProtectedSetStringA";
        public string PublicGetPrivateSetStringA { get; private set; } = "GrandparentA.PublicGetPrivateSetStringA";
        virtual public string PublicVirtualStringA { get; set; } = "GrandparentA.PublicVirtualStringA";
        virtual public string PublicDerivedStringA
        {
            get
            {
                return "GrandparentA.PublicDerivedStringA";
            }
        }

        // Constructors
        public GrandparentA()
        {
            Console.WriteLine("GrandparentA default constructor");
        }

        // Methods
        public string MethodA1(string input)
        {
            string s = $"GrandparentA.Method1:{input}";
            return s;
        }

        virtual public string VirtualMethodA2(string input)
        {
            string s = $"GrandparentA.VirtualMethodA2:{input}";
            return s;
        }
    }
}
