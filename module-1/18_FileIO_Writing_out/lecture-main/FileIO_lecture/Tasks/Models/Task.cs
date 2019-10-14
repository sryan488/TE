using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Models
{
    public class Task
    {
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
        public Task(string taskName, DateTime dueDate)
        {
            this.TaskName = taskName;
            this.DueDate = dueDate;
            this.Completed = false;
        }

        public Task(string taskName, DateTime dueDate, bool completed)
        {
            this.TaskName = taskName;
            this.DueDate = dueDate;
            this.Completed = completed;
        }
    }
}
