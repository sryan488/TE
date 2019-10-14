using System;
using System.IO;

namespace FizzWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"../../../../");

            string outPath = "..\\..\\..\\FizzBuzz.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(outPath, true))

                {
                    for (int i = 0; i <= 300; i++)
                    {

                        if (i % 15 == 0)
                        {
                            sw.WriteLine("FizzBuzz");
                        }
                        else if (i % 3 == 0)
                        {
                            sw.WriteLine("Fizz");
                        }
                        else if (i % 5 == 0)
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
