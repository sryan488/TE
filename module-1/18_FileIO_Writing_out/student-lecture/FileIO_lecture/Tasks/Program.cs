using System;
using System.Collections.Generic;
using Tasks.Models;

namespace Tasks
{
    class Program
    {
        static private TaskList tasks;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Task List!\r\n");

            tasks = new TaskList("Tasks.txt");
            tasks.Load();

            while (true)
            {
                Console.Clear();

                // List all the tasks
                ListTasks();

                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(A)dd a task");
                Console.WriteLine("(C)omplete a task");
                Console.WriteLine("(Q)uit");

                string input = Console.ReadLine().Trim().ToUpper();

                if (input.Length == 0)
                {
                    continue;
                }
                if (input.Substring(0, 1) == "Q")
                {
                    break;
                }
                int taskNumber;
                switch (input.Substring(0, 1))
                {
                    case "A":
                        // Prompt the user to add a task
                        Task task = GetTaskinfo();
                        tasks.AddTask(task);
                        break;

                    case "C":
                        taskNumber = GetTaskNumber();
                        task = tasks.List[taskNumber - 1];
                        task.Completed = true;
                        tasks.Save();
                        break;
                }
            }
        }

        private static int GetTaskNumber()
        {
            int taskNumber = 0;
            while (taskNumber <= 0 || taskNumber > tasks.Count)
            {
                // Prompt the user for a task# and complete it
                Console.Write("Task #: ");
                int.TryParse(Console.ReadLine().Trim(), out taskNumber);
            }
            return taskNumber;
        }

        private static void ListTasks()
        {
            Task[] list = tasks.List;
            string[] headings = {"Number", "Task", "Due Date", "Completed" };
            string dashes = new string('-', 63);
            Console.WriteLine($"{headings[0], 6} {headings[1],-30} {headings[2],-15} {headings[3],-10}");
            Console.WriteLine(dashes);
            for (int i = 0; i < list.Length; i++)
            {
                Task task = list[i];             
                Console.WriteLine($"{i+1, 6} {task.TaskName, -30} {task.DueDate,-15:d} {task.Completed, -10}");
            }
            Console.WriteLine(dashes);
        }

        private static Task GetTaskinfo()
        {
            Console.WriteLine("\r\n*** Add a Task ***");
            Console.Write("\tTask name: ");
            string taskName = Console.ReadLine();

            DateTime dueDate = DateTime.MinValue;
            while (dueDate == DateTime.MinValue)
            {
                try
                {
                    Console.Write("\tDue Date: ");
                    dueDate = DateTime.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("No!");
                }
            }

            return new Task(taskName, dueDate);

        }
    }
}
