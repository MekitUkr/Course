using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Entities;
using BLL;
using System;
namespace BLLTests
{
    class TestForQuestionEntity
    {
        [TestClass]
        public class TestForAnswerEntity
        {
            private static Test[] tests;
            private static Test oneTest;
            private static TestEntityService Tservice;
            private static TestDataContext Tcontext;
            private static QuestionEntityService Qservice;
            private Question question;
            [ClassInitialize]
            public static void ClassInitialize(TestContext testContext)
            {
                Console.WriteLine("Class initialized");
                Tservice = new TestEntityService();
                Tcontext = new TestDataContext();
                Qservice = new QuestionEntityService();
            }

            [TestInitialize]
            public void TestInitialize()
            {
                Console.WriteLine("Test initializing");
                oneTest = new Test("TEST");
                tests = new Test[] { oneTest };
                Tcontext.SetData(tests);
                question = new Question("MyTestQuestion");
                Console.WriteLine("Test initialized");
            }

            [TestMethod]
            public void TestAddingAndGettingQuestion()//додавання та отримання відповідей до/з файлу
            {
                Console.WriteLine("Adding question");
                Qservice.AddQuestion("TEST", question);
                Console.WriteLine("Question added");

                Console.WriteLine("Get from file our added test");
                Question serializedQuestion = Qservice.GetOneQuestionForTest("TEST",1);
                Console.WriteLine("if they equal - test passed");

                Assert.AreEqual(serializedQuestion.QuestionName, question.QuestionName, "Names are not equal");
            }

            [ExpectedException(typeof(IndexOutOfRangeException), "Exception wasn`t threw")]
            [TestMethod]
            public void TestRemovingQuestionFromDB()
            {
                Console.WriteLine("Adding question");
                Qservice.AddQuestion("TEST", question);
                Console.WriteLine("Question added");

                Console.WriteLine("Removing question");
                Qservice.RemoveData("TEST", 1);
                Console.WriteLine("Deleted");

                Qservice.GetOneQuestionForTest("TEST", 1);
            }

            [TestMethod]
            public void UpdateAnswerData()
            {
                Console.WriteLine("Adding question");
                Qservice.AddQuestion("TEST", question);
                Console.WriteLine("Question added");

                Console.WriteLine("Start answer data updating");

                Console.WriteLine("Updating question");
                Qservice.UpdateData("TEST", 1,"New question name");
                Console.WriteLine("Question updated");

                Console.WriteLine("Search question");
                Question MyQuestion = Qservice.GetOneQuestionForTest("TEST", 1);
                Console.WriteLine("Question searched");
                Assert.AreEqual(MyQuestion.QuestionName, "New question name","Captions are not equal");
            }

            [TestMethod]
            public void TestForCheckAnswer()
            {
                Console.WriteLine("Adding question");
                Qservice.AddQuestion("TEST", question);
                Console.WriteLine("Question added");
                Console.WriteLine("Get from file our added question");
                Question[] serializedQuestions = Qservice.getAllQuestionsForTest("TEST");//зараз в в отриманному массиві питань повинно бути лише 1 питання
                Console.WriteLine("if they equal - test passed");

                foreach (var item in serializedQuestions)
                {
                    Assert.AreEqual(item.QuestionName, question.QuestionName);
                }
            }
        }
    }
}
