using FileAndDirectory.Classes;
using System;
using System.IO;

namespace FileAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Navigator nav = new Navigator();
            nav.Run();

            Console.Write("Now, wasn't that FUN???");
            Console.ReadLine();

            return;
        }

    }
}
