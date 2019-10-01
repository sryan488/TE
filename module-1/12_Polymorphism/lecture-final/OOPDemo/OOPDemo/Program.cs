using OOPDemo.Models;
using System;

namespace OOPDemo
{
    class Program
    {
        /// <summary>
        /// Purpose of this program is to demonstrate the OO concepts and keywords we have used so far
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create a gp, parent and child. Follow the contructors
            Console.WriteLine("Creating a grandparent");
            GrandparentA gp = new GrandparentA();
            Console.WriteLine($"GP: {gp.PublicDerivedStringA} ");
            Console.WriteLine(gp.VirtualMethodA2("Foo"));


            Console.WriteLine(  "*****************************");
            Console.WriteLine("Creating a parent");
            ParentB p = new ParentB("Red");
            Console.WriteLine($"P: {p.PublicDerivedStringA}");
            Console.WriteLine(p.VirtualMethodA2("Bar"));


            Console.WriteLine("*****************************");
            Console.WriteLine("Creating a child");
            ChildC c = new ChildC("Brown", 11);
            Console.WriteLine($"C: {c.PublicDerivedStringA}");
            Console.WriteLine(c.VirtualMethodA2("Groovy"));


            // Get the Derived property on each and display it.


            // Execute the virtual method on each and diplay the result

            Console.ReadLine();
        }
    }
}
