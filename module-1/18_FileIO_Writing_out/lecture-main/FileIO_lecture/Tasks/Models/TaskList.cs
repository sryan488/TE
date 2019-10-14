using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tasks.Models
{
    public class TaskList
    {
        private const char SEPARATOR = '|';
        public string Path { get; }
        private List<Task> taskList { get; set; }
        public int Count
        {
            get
            {
                return this.taskList.Count;
            }
        }
        public Task[] List
        {
            get
            {
                return this.taskList.ToArray();
            }
        }

        public TaskList(string path)
        {
            this.Path = path;
        }

        public void Load()
        {
            this.taskList = new List<Task>();

            // TODO: Load tasks from the file (in Path), parse and create Tasks, add them to the list

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        string inputLine = sr.ReadLine();
                        string[] fields = inputLine.Split(SEPARATOR);
                        Task task = new Task(fields[0], DateTime.Parse(fields[1]), bool.Parse(fields[2]));
                        taskList.Add(task);
                    }
                }
            }
            catch(Exception myException)
            {
                // Inform the user
                Console.WriteLine($"There was an ERROR loading the file {Path}. The error was {myException.Message}");
                Console.ReadLine();
            }

        }

        public void Save()
        {
            // Open the file at Path, and write all the tasks there
            try
            {
                using (StreamWriter writer = new StreamWriter(this.Path, false))
                {
                    foreach (Task task in taskList)
                    {
                        string outputData = string.Join(SEPARATOR, task.TaskName, task.DueDate, task.Completed);
                        writer.WriteLine(outputData);
                    }
                }
            }
            catch (Exception ex)
            {
                // Report to the user that there was an error
                Console.WriteLine($"ERROR saving task list: {ex.Message}.  Please call support at 867-5309");
                Console.ReadLine();
            }
        }

        public void AddTask(Task newTask)
        {
            this.taskList.Add(newTask);
            this.Save();
        }

        public void RemoveTask(Task taskToRemove)
        {
            if (this.taskList.Contains(taskToRemove))
            {
                this.taskList.Remove(taskToRemove);
                this.Save();
            }
        }

    }
}
