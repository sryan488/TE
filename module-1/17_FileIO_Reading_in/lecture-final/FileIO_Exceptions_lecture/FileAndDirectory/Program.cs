using FileAndDirectory.Classes;
using System;
using System.IO;

namespace FileAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {

            // Get current direcory
            // Bash: pwd
            string currentPath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Dir is '{currentPath}'");

            // List the files that are here
            // Bash: ls
            string[] files = Directory.GetFiles(currentPath);
            Console.WriteLine("\r\nFiles in this Dir:");
            foreach (string file in files)
            {
                string relPath = Path.GetRelativePath(currentPath, file);
                Console.WriteLine(relPath);
            }

            // List the files that are in my great-grandparent dir
            // Bash: ls ../../..
            files = Directory.GetFiles("..\\..\\..");
            Console.WriteLine("\r\nFiles in my Great GrandParent:");
            foreach (string file in files)
            {
                string relPath = Path.GetRelativePath(currentPath, file);
                Console.WriteLine(relPath);
            }

            // Change Directory to Great Grandparent
            // Bash: cd ../../..
            Directory.SetCurrentDirectory(@"..\..\..");

            // Now make sure I am there
            // Get current direcory
            // Bash: pwd
            currentPath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Dir is '{currentPath}'");

            //// Go to some specific path on the disk
            //Directory.SetCurrentDirectory(@"C:\Program Files\dotnet");
            //// List the files that are in my great-grandparent dir
            //// Bash: ls ../../..
            //files = Directory.GetFiles(".");
            //Console.WriteLine("\r\nFiles in C:\\Program Files\\dotnet");
            //foreach (string file in files)
            //{
            //    string relPath = Path.GetRelativePath(currentPath, file);
            //    Console.WriteLine(relPath);
            //}

            try
            {
                Console.WriteLine("Before opening the file");
                using (StreamReader stream = new StreamReader("Program.cs"))
                {
                    Console.WriteLine("After opening the file");
                    while (!stream.EndOfStream)
                    {
                        int y = 0;
                        int i = 0 / y;
                        string line = stream.ReadLine();
                        Console.WriteLine(line);
                    }
                    Console.WriteLine("After End of stream");
                }
            }
            catch(FileNotFoundException fnfe)
            {
                // Write an error to the log

                // Send an SMS to the developer

                // Inform the user
                Console.WriteLine($"In FileNotFound Exception handler.  The missing file was named {fnfe.FileName}");
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"In general Exception handler {ex.Message}");
            //}
            finally
            {
                Console.WriteLine("In the FINALLY block");
            }

            Console.WriteLine("AFTER EVERYTHING");

                //Navigator nav = new Navigator();
                //nav.Run();

            //Console.Write("Now, wasn't that FUN???");
            Console.ReadLine();

            return;
        }

    }
}
