using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Views
{
    public class QuizTaker
    {
        private Quiz quiz;
        public QuizTaker(Quiz quiz)
        {
            if (quiz == null)
            {
                throw new NullReferenceException("You must pass a Quiz into QuizTaker");
            }
            this.quiz = quiz;
        }

        public void TakeQuiz(bool immediateFeedback)
        {
            ConsoleUserInterface ui = new ConsoleUserInterface();
            foreach (Question question in quiz.Questions)
            {
                question.DisplayAndGetAnswer(ui, immediateFeedback);
            }

            // Quiz is complete, give a final score
            ui.WriteLine($"Quiz is COMPLETE. Your score was {quiz.Score}%");
        }
    }
}
