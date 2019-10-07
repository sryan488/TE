using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class MultipleChoiceQuestion : Question
    {
        public Dictionary<string, string> PossibleResponses { get; }

        public MultipleChoiceQuestion(string questionText, string correctResponse, Dictionary<string, string> possibleResponses) : base(questionText, correctResponse, false)
        {
            this.PossibleResponses = possibleResponses;
        }

        protected override void DisplayQuestion(IUserInterface ui)
        {
            base.DisplayQuestion(ui);
            foreach (KeyValuePair<string, string> pr in PossibleResponses)
            {
                ui.WriteLine($"\t{pr.Key} - {pr.Value}");
            }
        }

        protected override string GetAnswer(IUserInterface ui)
        {
            string answer = "";
            while (answer == "")
            {
                ui.Write("Select one: ");
                string response = ui.ReadLine();
                if (this.PossibleResponses.ContainsKey(response))
                {
                    answer = response;
                }
            }
            return answer;
        }
    }
}
