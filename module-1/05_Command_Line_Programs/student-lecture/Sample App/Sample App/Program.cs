using System;

namespace Sample_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //for(int counter = 1; counter <= 5; counter++)
            //{
            //  Console.Write("Hello");
            //}

            //Console.Write("Please enter your name: ");
            //string userName = Console.ReadLine();

            //Get the user's age
            //Console.Write("Enter your age: ");
            //string userAge = Console.ReadLine();

            //int age = int.Parse(userAge);


            //Console.WriteLine("Hello, " + userName + "!!!");
            //Console.WriteLine($"Wow! In 10 years, you are going to be {age + 10} years old!!!");


            // Ask the user for a series of numbers. We will average them.

            //Condition is the only thing you really need to run
            //for (; true; )

            //while (true)
            //{
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=======================================");
            Console.Write("Please enter numbers seperated by comma (Press only Enter to Exit): ");
            string userInput = Console.ReadLine();

            if (userInput == "")
            {
                break;
            }

            string[] strings = userInput.Split(",");

            int sum = 0;
            for (int i = 0; i < strings.Length; i++)
            {
                int num = int.Parse(strings[i]);
                sum += num;
            }
            double average = ((double)sum) / strings.Length;

            string equation = string.Join(" + ", strings);

            Console.WriteLine($"{equation} = {sum}");
            Console.WriteLine($"The average is {average}");

            Console.ReadLine();
        }

        
    }
}
