using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizApp.Models
{
    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public string Name { get; set; }
        public double Score
        {
            get
            {
                int numQuestions = 0;
                double total = 0.0;
                foreach (Question q in Questions)
                {
                    if (q.IsComplete)
                    {
                        numQuestions++;
                        total += q.Correctness;
                    }
                }
                return (numQuestions > 0) ? total * 100 / numQuestions : 0.0;
            }
        }   // 0.0 - 100.0
        public bool IsComplete
        {
            get
            {
                return Questions.Where(q => !q.IsComplete).Count() == 0;
            }

        }

    }
}
