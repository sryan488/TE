using System;
using System.IO;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Ask the user for the search string
            Console.WriteLine("Please enter the search string: ");
            string search = Console.ReadLine();
          
            //2. Ask the user for the file path
            Console.WriteLine("Please enter the file path: "); //C:\Users\SRyan\git\seanryan-c\module-1\17_FileIO_Reading_in\student-exercise\alices_adventures_in_wonderland.txt
            string file = Console.ReadLine();

            //3. Open the file

             using (StreamReader stream = new StreamReader(file))
            
            //4. Loop through each line in the file

            while(!stream.EndOfStream)
            {
                string currentLine = stream.ReadLine();

            }


            //5. If the line contains the search string, print it out along with its line number

            Console.ReadLine();
        }
    }
}
