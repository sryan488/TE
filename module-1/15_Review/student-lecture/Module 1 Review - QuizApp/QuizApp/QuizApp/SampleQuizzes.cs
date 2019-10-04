using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp
{
    public class SampleQuizzes
    {
        /****
        public static Quiz TheBridgeOfDeath
        {
            get
            {
                return new Quiz()
                {
                    Name = "The Bridge of Death",
                    Questions = new List<Question>()
                {
                    new FillInQuestion("What is your name?", "Arthur, King of the Britons", false, true),
                    new FillInQuestion("What is your quest?", "To seek the Holy Grail", false, true),
                    new MultipleChoiceQuestion("What is your favorite color?", "C",
                    new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase){
                        {"A", "Green" },
                        {"B", "Red" },
                        {"C", "Blue" },
                        {"D", "No, Yel..." },
                        {"E", "Aaaaah!" },
                    }),
                    new TrueFalseQuestion("Is it an African swallow?", "true")
                }
                };
            }

        }

        public static Quiz VariablesAndDataTypes
        {
            get
            {
                return new Quiz()
                {
                    Name = "Module 1 Variables and Data Types",
                    Questions = new List<Question>()
                {
                    new MultipleChoiceQuestion("Which of the below follow camel-case conventions?", "A",
                    new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase){
                        {"A", "int numberOfDaysPerWeek;" },
                        {"B", "string StudentName;" },
                        {"C", "decimal Price = 20.0M;" },
                        {"D", "const float PI;" },
                        {"E", "I don't know" },
                    }),
                    new MultipleChoiceQuestion("Which is a correct declaration of a?", "B",
                    new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase){
                        {"A", "int a = 40.6;" },
                        {"B", "int a = 42;" },
                        {"C", "int a = b = 42;" },
                    }),
                    new MultipleChoiceQuestion("Which of the following is the correct way to assign a value 3.14 to the variable Pi so that it cannot be modified?", "C",
                    new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase){
                        {"A", "double Pi = 3.14;" },
                        {"B", "#define Pi 3.14" },
                        {"C", "const double Pi = 3.14;" },
                        {"D", "const double Pi; Pi = 3.14;" },
                        {"E", "Pi = 3.14;" },
                    }),
                    new FillInQuestion("What is the value of a after the following statement of code?\r\nint a = 7 / 2;", "3", false, true),
                    new FillInQuestion("What is the value of a after the following statement of code?\r\ndouble a = 7 / 2;", "3.0", false, true),
                    new FillInQuestion("What is the value of a after the following statement of code?\r\nint a = 7 % 2;", "1", false, true),
                }
                };
            }
        }
        ****/
    }
}

