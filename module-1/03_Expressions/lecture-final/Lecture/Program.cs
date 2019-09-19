using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Declare a variable
            int outerVariable = 5;
            Console.WriteLine("outerVariable is " + outerVariable);

            // Start a statement block
            {

                // Print out the variable defined in the outer scope

                // outerVariable = outerVariable + 10;
                outerVariable += 10;

                Console.WriteLine("outerVariable from the inner block is " + outerVariable);

                // Declare a variable in the block (inner scope)
                int innerVariable = 10;

                // Print out that variable
                Console.WriteLine("innerVariable is " + innerVariable);

                // End the statement block
            }

            Console.WriteLine("outerVariable is " + outerVariable);

            // Print the the variable declared in the block
            // I CANNOT do this!!
            //Console.WriteLine("innerVariable from the outer block is " + innerVariable);


            // Create and call a method
            int length = 50;
            int width = 100;
            int area = MultipleBy(length, width);

            Console.WriteLine("The area is " + area);

            // Create and print some boolean expressions


            Console.ReadKey();
        }

        static public int MultipleBy(int multiplicand, int multiplier)
        {
            int product = multiplicand * multiplier;
            return product;
        }
    }
}
