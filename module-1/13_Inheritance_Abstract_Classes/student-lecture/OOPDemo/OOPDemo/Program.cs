using OOPDemo.Models;
using System;
using System.Collections.Generic;

namespace OOPDemo
{
    class Program
    {
        static List<Person> people = new List<Person>()
        {
            new Person("Barney", "Rubble", 1950, 12, 12, 5000),
            new Person("Betty", "Rubble", 1954, 1, 8, 30000),
            new Person("Fred", "Flintstone", 1948, 3, 15, 32000),
            new Person("Wilma", "Flintstone", 1955, 11, 10, 8000),

        };

        /// <summary>
        /// Purpose of this program is to demonstrate the OO concepts and keywords we have used so far
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DisplayPeople();
            Console.ReadLine();
            return;

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

        public static void DisplayPeople()
        {
            foreach (Person p in people)
            {
                Console.WriteLine($"{p.LastName} {p.FirstName} {p.BirthDate} {p.Age} {p.Income}");
            }
        }
    }
}
