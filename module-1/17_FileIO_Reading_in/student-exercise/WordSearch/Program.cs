using System;
using System.IO;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"../../../../");

            Console.WriteLine("Please enter the file path: "); //alices_adventures_in_wonderland.txt
            string filePath = Console.ReadLine();

            Console.WriteLine("Please enter the word to search: ");
            string search = Console.ReadLine().Trim();
          

            Console.WriteLine("Should the search be case sensative? (Y/N)");
            string caps = Console.ReadLine().ToLower();

            if (caps == "y")
            {

            
                int counter = 0;
                string line = null;
                using (StreamReader stream = new StreamReader(filePath))
                while (!stream.EndOfStream)
                    {
                        counter++;
                        line = stream.ReadLine();
                        line.Trim();

                        if (line.Contains(search))
                        {
                            Console.WriteLine($"{counter}) {line}");
                        }

                    }
            }
            else
            {
                

                int counter = 0;
                string line = null;
                using (StreamReader stream = new StreamReader(filePath))
                    while (!stream.EndOfStream)
                    {
                        counter++;
                        line = stream.ReadLine();
                        line.Trim();

                        if (line.Contains(search))
                        {
                            Console.WriteLine($"{counter}) {line}");
                        }
                        if (line.Contains(search.ToLower()))
                        {
                            Console.WriteLine($"{counter}) {line}");
                        }
                    }
            }



            Console.ReadLine();
        }
    }
}
