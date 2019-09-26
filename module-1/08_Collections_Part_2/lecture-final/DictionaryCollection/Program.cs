using System;
using System.Collections.Generic;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            //// Queue up some items

            //Queue<string> todo = new Queue<string>();
            //todo.Enqueue("Wake up");
            //todo.Enqueue("Drink coffee");
            //todo.Enqueue("Eat breakfast");
            //todo.Enqueue("Brush teeth");

            //Console.WriteLine($"Queue: {string.Join(";", todo)}");

            //List<string> list = new List<string>();

            ////while (todo.Count > 0)
            ////{
            ////    list.Add(todo.Dequeue());
            ////}

            //list.AddRange(todo);
            //todo.Clear();

            //Console.WriteLine($"Queue: {string.Join(";", todo)}");
            //Console.WriteLine($"List: {string.Join(";", list)}");


            //Console.ReadLine();
            //return;




            Console.WriteLine("Welcome to the Person / Height Database");
            Console.WriteLine();

            Console.Write("Would you like to enter another person (yes/no)? ");
            string input = Console.ReadLine().ToLower();

            // 1. Let's create a new Dictionary that could hold string, ints
            //      | "Josh"    | 70 |
            //      | "Bob"     | 72 |
            //      | "John"    | 75 |
            //      | "Jack"    | 73 |

            Dictionary<string, int> nameHeights = new Dictionary<string, int>()
            {
                {"Mike", 71},
                {"Ron", 312 }
            };

            while (input == "yes" || input == "y")
            {
                Console.Write("What is the person's name?: ");
                string name = Console.ReadLine().Trim();
                name = MakeProper(name);

                Console.Write("What is the person's height (in inches)?: ");
                int height = int.Parse(Console.ReadLine());

                // 2. Check to see if that name is in the dictionary
                //      bool exists = dictionaryVariable.ContainsKey(key)
                bool exists = nameHeights.ContainsKey(name);

                if (exists)
                {
                    Console.WriteLine($"Overwriting {name} with new value.");
                    // 4. Overwrite the current key with a new value
                    //      dictionaryVariable[key] = value;
                    nameHeights[name] = height;

                }
                else  // "name" does not exist yet
                {
                    Console.WriteLine($"Adding {name} with new value.");
                    // 3. Put the name and height into the dictionary
                    //      dictionaryVariable[key] = value;
                    //      OR dictionaryVariable.Add(key, value);
                    nameHeights.Add(name, height);
                }


                Console.WriteLine();
                Console.Write("Would you like to enter another person (yes/no)? ");
                input = Console.ReadLine().ToLower();
            }

            Console.Write("Type \"all\" to print all names OR \"search\" to print out single name: ");
            input = Console.ReadLine().ToLower();

            if (input == "search")
            {
                Console.Write("Which name are you looking for? ");
                input = Console.ReadLine().Trim();
                input = MakeProper(input);

                //5. Let's get a specific name from the dictionary
                if (nameHeights.ContainsKey(input))
                {
                    Console.WriteLine($"{input} was found, and is {nameHeights[input]} inches tall.");
                }
                else
                {
                    Console.WriteLine($"'{input}' was not found in the database");
                }

            }
            else if (input == "all")
            {
                Console.WriteLine();
                Console.WriteLine(".... printing ...");

                //6. Let's print each item in the dictionary
                foreach (KeyValuePair<string, int> entry in nameHeights)
                {
                    Console.WriteLine($"Name: {entry.Key}, Height: {entry.Value}");
                }

                // If we wanted to just get all the names, we could do this.

                //foreach (string k in nameHeights.Keys)
                //{
                //    Console.WriteLine(k);
                //}

            }

            Console.WriteLine();
            Console.WriteLine("Done...");

            //7. Let's get the average height of the people in the dictionary
            int totalHeight = 0;
            foreach (int v in nameHeights.Values)
            {
                totalHeight += v;
            }
            Console.WriteLine($"The average height in the db is {totalHeight / (double)nameHeights.Values.Count}.");


            // Demonstrate HashSet Union 
            HashSet<string> hs1 = new HashSet<string>() { "A", "B", "C" };
            HashSet<string> hs2 = new HashSet<string>() { "F", "E", "D", "C" };

            hs1.UnionWith(hs2);

            Console.WriteLine($"hs1: {string.Join(";", hs1)}");
            Console.WriteLine($"hs2: {string.Join(";", hs2)}");

            // Demonstrate HashSet Intersection 
            hs1 = new HashSet<string>() { "A", "B", "C" };
            hs2 = new HashSet<string>() { "F", "E", "D", "C" };

            hs1.IntersectWith(hs2);

            Console.WriteLine($"hs1: {string.Join(";", hs1)}");
            Console.WriteLine($"hs2: {string.Join(";", hs2)}");



            Console.ReadLine();
        }

        static void PrintDictionary(Dictionary<string, int> database)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
        }

        /// <summary>
        /// THis method takes a string and chages its case to Proper Noun case.
        /// </summary>
        /// <param name="str">The input string</param>
        /// <returns>The string as a proper noun</returns>
        static public string MakeProper(string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
        }
    }
}
