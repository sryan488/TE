using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the temperature: ");
            string userInput = Console.ReadLine();

            double temp = double.Parse(userInput);

            Console.Write("Is the temperature in (C)elsius, or (F)arenheit? ");
            string whichTemp = Console.ReadLine();


            if (whichTemp == "C" || whichTemp == "c")
            {
                double conversion = (temp * 1.8) + 32;

                Console.Write($"{userInput}C is {conversion}F");
            }
            if (whichTemp == "F" || whichTemp == "f")
            {
                double conversion = (temp - 32) - 18;

                Console.Write($"{userInput}F is {conversion}C");
            }
            




            Console.ReadLine();
        }
    }
}
