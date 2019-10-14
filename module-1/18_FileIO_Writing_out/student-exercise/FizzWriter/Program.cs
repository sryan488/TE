using System;
using System.IO;

namespace FizzWriter
{
    class Program
    {
        static void Main(string[] args)
        {


            string outPath = "..\\..\\..\\..\\FizzBuzz.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(outPath, true))

                {
                    for (int i = 1; i <= 300; i++)
                    {

                        if (i % 15 == 0 || i.ToString().Contains("3") && i.ToString().Contains("5"))
                        {
                            sw.WriteLine("FizzBuzz");
                        }
                        else if (i % 3 == 0 || i.ToString().Contains("3"))
                        {
                            sw.WriteLine("Fizz");
                        }
                        else if (i % 5 == 0 || i.ToString().Contains("5"))
                        {
                            sw.WriteLine("Buzz");
                        }
                        else 
                        {
                            sw.WriteLine(i);
                        }


                    }
                }
            }
            catch(Exception x)
            {
                Console.WriteLine($"There was an ERROR: {x.Message}");
            }

        }
    }
}
