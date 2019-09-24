using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the lentgh: ");
            string userInput = Console.ReadLine();

            double length = double.Parse(userInput);

            Console.Write("Is the measurement in (m)eters, or (f)eet? ");
            string measurement = Console.ReadLine();

            if (measurement == "f" || measurement == "F")
            {
                double conversion = (length * .3048);

                Console.Write($"{userInput}f is {conversion}m");
            }
            if (measurement == "m" || measurement == "M")
            {
                double conversion = (length * 3.2808399);



                Console.Write($"{userInput}m is {conversion}f");
            }

            Console.ReadLine();
        }
    }
}
