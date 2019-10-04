using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppTests
{
    class MockUI : IUserInterface
    {
        public MockUI(string[] userInput)
        {
            UserInput = new List<string>(userInput);
        }

        public List<string> UserInput { get; }
        public List<string> ProgramOutput { get; } = new List<string>();

        public void Clear()
        {
            // Do nothing for clear
        }

        public string ReadLine()
        {
            // Respond with the first line from the user input list
            if (UserInput.Count == 0)
            {
                throw new Exception("Mock UI was not supplied enough input lines!");
            }
            string input = UserInput[0];
            UserInput.RemoveAt(0);
            return input;
        }

        public void Write(string s)
        {
            // Capture the putput of the program
            ProgramOutput.Add(s);
        }

        public void WriteLine(string s)
        {
            ProgramOutput.Add(s+"\r\n");
        }
    }
}
