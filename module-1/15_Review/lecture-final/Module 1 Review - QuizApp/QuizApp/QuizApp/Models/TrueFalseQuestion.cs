using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string questionText, string correctResponse) : base(questionText, correctResponse, false)
        {
        }

        protected override string GetAnswer(IUserInterface ui)
        {
            string answer = "";
            while (answer == "")
            {
                ui.Write("Answer (true or false): ");
                string response = ui.ReadLine();

                switch (response)
                {
                    case "y":
                    case "t":
                    case "yes":
                    case "true":
                        answer = "true";
                        break;
                    case "n":
                    case "no":
                    case "f":
                    case "false":
                        answer = "false";
                        break;
                }
            }
            return answer;
        }
    }
}
