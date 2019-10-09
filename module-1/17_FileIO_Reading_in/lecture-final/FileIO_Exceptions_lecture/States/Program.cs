using States.Model;
using System;
using System.Collections.Generic;

namespace States
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter a state code (Q to Quit): ");
                string stateCode = Console.ReadLine().ToUpper().Trim();

                if (stateCode == "Q")
                {
                    break;
                }

                State state = LookupStateName(stateCode);

                if (state == null)
                {
                    Console.WriteLine($"Code {stateCode} was not found");
                }
                else
                {
                    Console.WriteLine($"The name of the state with code '{stateCode}' is {state.Name}. Its capital is {state.Capital}");
                }
            }

            Console.WriteLine("Thanks for using our awesome program! Press any key to exit.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }

        static public State LookupStateName(string stateCode)
        {
            return null;
        }
    }
}
