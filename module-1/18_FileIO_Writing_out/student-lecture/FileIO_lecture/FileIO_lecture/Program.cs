using System;
using System.IO;

namespace FileIO_lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output will go to thid file
            string outPath = "..\\..\\..\\Folders.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(outPath, true))
                {
                    string sPath = "C:\\Users";

                    //This returns an array of strings
                    string[] dirs1 = Directory.GetDirectories(sPath);

                    sw.WriteLine($"Subfolders of {sPath} at {DateTime.UtcNow:f}:");

                    foreach (string subfolder in dirs1)
                    {
                        sw.WriteLine($"\t{subfolder}");
                    }

                }
            }
            catch(Exception ex)
            {
                //Tell the user that there is a problem
                Console.WriteLine($"There was an EROOR: {ex.Message}");
            }



            Console.WriteLine("Press RETURN");
            Console.ReadKey();
        }
    }
}
