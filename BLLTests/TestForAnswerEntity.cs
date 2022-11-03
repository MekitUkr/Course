using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Entities;
using BLL;
using System;
namespace BLLTests
{
    [TestClass]
    public class TestForAnswerEntity
    {
        private static  Test[] tests;
        private static Test oneTest;
        private static TestEntityService Tservice;
        private static TestDataContext Tcontext;
        private static AnswerEntityService Aservice;
        private Answer answer;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("Class initialized");
            Tservice = new TestEntityService();
            Tcontext = new TestDataContext();
            Aservice = new AnswerEntityService();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("Test initializing");

            Question[] questions = new Question[] { new Question("firstQuestion") };
            oneTest = new Test("TEST", questions);
            tests = new Test[] { oneTest };
            Tcontext.SetData(tests);
            answer = new Answer("My answer",true);

            Console.WriteLine("Test initialized");
        }

        [TestMethod]
        public void TestAddingAndGettingAnswer()//додавання та отримання відповіді до/з файлу
        {
            Console.WriteLine("Adding answer");
            Aservice.AddAnswer("TEST",1, answer);
            Console.WriteLine("Answer added");

            Console.WriteLine("Get from file our added answer");
            Answer serializedAnswer = Aservice.GetOneAnswerForQuestion("TEST",1,1);
            Console.WriteLine("if they equal - test passed");

            Assert.AreEqual(serializedAnswer.MyAnswer, answer.MyAnswer, "Names are not equal");
        }

        [ExpectedException(typeof(Exception), "Exception wasn`t threw")]
        [TestMethod]
        public void TestRemovingAnswerFromDB()
        {
            Console.WriteLine("Adding answer");
            Aservice.AddAnswer("TEST", 1, answer);
            Console.WriteLine("Answer added");

            Console.WriteLine("Removing answer");
            Aservice.RemoveData("TEST", 1, 1);
            Console.WriteLine("Deleted");

            Aservice.GetOneAnswerForQuestion("TEST",1,1);
        }

        [TestMethod]
        public void UpdateAnswerData()
        {
            Console.WriteLine("Adding answer");
            Aservice.AddAnswer("TEST", 1, answer);
            Console.WriteLine("Answer added");

            Console.WriteLine("Start answer data updating");

            Console.WriteLine("Updating answer");
            Aservice.UpdateData("TEST", 1,1,"NewAnswerName", false);
            Console.WriteLine("Answer updated");

            Console.WriteLine("Search answer");
            Answer MyAnswer = Aservice.GetOneAnswerForQuestion("TEST", 1, 1);
            Console.WriteLine("Answer searched");
            Assert.AreEqual(MyAnswer.IsRight, false);
            Assert.AreEqual(MyAnswer.MyAnswer, "NewAnswerName");
        }

        [TestMethod]
        public void TestForCheckAnswer()
        {
            Console.WriteLine("Adding answer");
            Aservice.AddAnswer("TEST", 1, answer);
            Console.WriteLine("Answer added");
            bool variable = Aservice.CheckAnswer("TEST", 1, 1);
            Assert.AreEqual(variable, true, "Answer checking wasn`t passed");
        }

        [TestMethod]
        public void TestAddingAndGettingAnswers()//додавання та отримання відповідей до/з файлу
        {
            Console.WriteLine("Adding answer");
            Aservice.AddAnswer("TEST", 1, answer);
            Console.WriteLine("Answer added");

            Console.WriteLine("Get from file our added answer");
            Answer[] serializedAnswers = Aservice.GetAllAnswersForQuestion("TEST", 1);//зараз в в отриманному массиві відповідей повинна бути лише 1 відповідь
            Console.WriteLine("if they equal - test passed");

            foreach(var item in serializedAnswers)
            {
                Assert.AreEqual(item.MyAnswer, answer.MyAnswer);
            }
        }
    }
}
