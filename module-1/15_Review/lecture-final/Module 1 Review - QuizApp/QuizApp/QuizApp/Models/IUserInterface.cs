using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public interface IUserInterface
    {
        void Clear();
        void Write(string s);
        void WriteLine(string s);
        string ReadLine();
    }
}
