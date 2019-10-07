using QuizApp.Models;
using QuizApp.Views;
using System;
using System.Collections.Generic;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            QuizTaker quizTaker = new QuizTaker(SampleQuizzes.VariablesAndDataTypes);
            quizTaker.TakeQuiz(true);

            Console.ReadLine();


            quizTaker = new QuizTaker(SampleQuizzes.TheBridgeOfDeath);
            quizTaker.TakeQuiz(true);

            Console.WriteLine();
            Console.WriteLine("Thanks for playing - Please come back soon!");
            Console.ReadLine();
        }
    }
}
