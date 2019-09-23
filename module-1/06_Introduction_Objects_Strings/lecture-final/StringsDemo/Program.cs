using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            string firstCharacter = name[0].ToString();
            string lastCharacter = name[name.Length - 1].ToString();
            Console.WriteLine($"First and Last Characters are {firstCharacter} and {lastCharacter}, respectively.");

            // 2. How do we write code that prints out the first three characters
            // Output: Ada
            
            Console.WriteLine($"First 3 characters: {name.Substring(0, 3)}");

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine($"First and Last 3 characters: {name.Substring(0, 3)}-{name.Substring(name.Length-3)}");

            // 4. What about the last word?
            // Output: Lovelace
            string[] names = name.Split(" ");
            string lastName = names[names.Length - 1];
            Console.WriteLine($"Last Word: {lastName}");


            // 5. Does the string contain inside of it "Love"?
            // Output: true

            bool containsLove = name.ToLower().Contains("love");
//            bool containsLove = name.Contains("love", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine($"Contains \"Love\": {containsLove}");

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine($"Index of \"lace\": {name.IndexOf("lace")}");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            string[] tokens = name.ToLower().Split("a");
            Console.WriteLine($"Number of \"a's\": {tokens.Length - 1}");

            int countOfA = 0;
            string lowerName = name.ToLower();
            for (int i = 0; i < lowerName.Length; i++)
            {
                if (lowerName[i] == 'a')
                {
                    countOfA++;
                }
            }
            Console.WriteLine($"Number of \"a's\": {countOfA}");

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"
            Console.WriteLine(name.Replace("Ada", "Ada, Countess of Lovelace"));

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (name == null || name == "")
            {
                Console.WriteLine("All Done");
            }


            Console.ReadLine();
        }
    }
}