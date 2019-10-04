using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApp.Models;

namespace QuizAppTests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void TrueFalseQuestionTest()
        {
            Question question = new TrueFalseQuestion("A True Question", "true");

            // Question should be NOT complete
            Assert.IsFalse(question.IsComplete);

            // Create a mock ui which will pass "true" in as user input
            MockUI ui = new MockUI(new string[]{ "true", "" }); // Last input is for the ReadLine after immedite feedback

            question.DisplayAndGetAnswer(ui, true);

            // Question should be correct (1.0) and Complete
            Assert.IsTrue(question.IsComplete);
            Assert.AreEqual(1.0, question.Correctness);
        }
    }
}
