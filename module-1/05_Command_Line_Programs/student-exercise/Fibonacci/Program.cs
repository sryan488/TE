using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the Fibonacci number: ");
            string userInput = Console.ReadLine();

            int number = int.Parse(userInput);

            int nOne = 0;
            int nTwo = 1;
            int nThree = nOne + nTwo;
            Console.Write("0, 1");

            //for (int i = 0; nThree <= number; i++)
            while (true)
            {
                //if (i == 0)
                //{
                //    Console.Write("0");
                //}
                //else if (i == 1)
                //{
                //    Console.Write(", 1");
                //}
                //else
                {
                    nThree = nOne + nTwo;
                    nOne = nTwo;
                    nTwo = nThree;
                    Console.Write($", {nThree}");
                    if (nOne + nTwo > number)
                    {
                        break;
                    }
                }
            }



            Console.ReadLine();
        }
    }
}
