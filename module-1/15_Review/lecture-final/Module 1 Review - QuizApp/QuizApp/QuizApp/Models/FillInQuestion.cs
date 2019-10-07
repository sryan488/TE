using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class FillInQuestion : Question
    {
        public bool TrimResponse { get; set; }
        public FillInQuestion(string questionText, string correctResponse, bool isCaseSensitive, bool trimResponse) : base(questionText, correctResponse, isCaseSensitive)
        {
            this.TrimResponse = trimResponse;
        }

        protected override string GetAnswer(IUserInterface ui)
        {
            if (TrimResponse)
            {
                return base.GetAnswer(ui).Trim();
            }
            else
            {
                return base.GetAnswer(ui);
            }
        }
    }
}
