using System;
using System.Collections.Generic;
namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //
            // Creating lists of integers
            List<int> numbers = new List<int>();
            Console.WriteLine(numbers);
            Console.WriteLine(string.Join(",", numbers));

            // Creating lists of strings
            List<string> words = new List<string>() { "cat", "BAT", "dragon", "apple" };
            Console.WriteLine(words);
            Console.WriteLine(string.Join(",", words));

            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////


            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            numbers.Add(100);
            numbers.Add(200);
            words.Add("zzz");
            Console.WriteLine(string.Join(",", numbers));
            Console.WriteLine(string.Join(",", words));

            words.Insert(3, "dd");
            Console.WriteLine(string.Join(",", words));

            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////

            int[] newNumbers = new int[] { 11, 22, 33, 44 };
            numbers.AddRange(newNumbers);
            Console.WriteLine(string.Join(",", numbers));

            numbers.AddRange(new int[]{ 99, 88});
            Console.WriteLine(string.Join(",", numbers));

            //////////////////
            // ACCESSING BY INDEX
            //////////////////
            Console.WriteLine(words[0]);
            words[0] = "alpha";
            Console.WriteLine(string.Join(",", words));




            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            int sum = 0;
            foreach(int n in numbers)
            {
                sum += n;
            }
            Console.WriteLine($"The sum is {sum}");



            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////

            Console.WriteLine($"Does words contain alpha? {words.Contains("alpha")}");
            Console.WriteLine($"Does words contain delta? {words.Contains("delta")}");


            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////
            words.Sort();
            Console.WriteLine(string.Join(",", words));

            words.Reverse();


            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.
            Queue<string> priorities = new Queue<string>();

            priorities.Enqueue("Clean the dishes");
            priorities.Enqueue("Wash the counters");
            priorities.Enqueue("Sweep the floor");
            priorities.Enqueue("Scrub the floor");


            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            while (priorities.Count > 0)
            {
                string nextPriority = priorities.Dequeue();
                Console.WriteLine("NEXT PRIORITY " + nextPriority);
            }


            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 

            Stack<string> browserStack = new Stack<string>();
            browserStack.Push("Home page");
            browserStack.Push("Login Page");
            browserStack.Push("Dashboard");

            Console.WriteLine(string.Join(", ", browserStack));

            ////////////////////
            // POPPING THE STACK
            ////////////////////
            string previousPage = browserStack.Pop();
            Console.WriteLine($"Previous page is {previousPage}");
            Console.WriteLine(string.Join(", ", browserStack));

            previousPage = browserStack.Peek();
            Console.WriteLine($"Previous page is {previousPage}");
            Console.WriteLine(string.Join(", ", browserStack));

            while (browserStack.Count > 0)
            {
                Console.WriteLine(browserStack.Pop());
            }
            Console.WriteLine(string.Join(", ", browserStack));

            


            Console.ReadLine();

        }
    }
}

