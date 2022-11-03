using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Entities;
using BLL;
using System;
namespace BLLTests
{
    [TestClass]
    public class TestForTestEntity
    {
        private Test[] tests;
        private Test oneTest;
        private static TestEntityService service;
        private static TestDataContext context;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("Class initialized");
            service = new TestEntityService();
            context = new TestDataContext();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("Test initializing");
            tests = new Test[] { };
            oneTest = new Test("TEST");
            context.SetData(tests);
            Console.WriteLine("Test initialized");
        }

        [TestMethod]
        public void TestAddingAndGettingTest()//додавання та отримання тестів до/з файлу
        {
            Console.WriteLine("Adding test");
            service.AddTest(oneTest);
            Console.WriteLine("Test added");
            Console.WriteLine("Get from file our added test");
            Test serializedTest = service.GetOneTest("TEST");
            Console.WriteLine("if they equal - test passed");
            Assert.AreEqual(serializedTest.Name, oneTest.Name, "Names are not equal");
        }

        [ExpectedException(typeof(Exception), "Exception wasn`t threw")]
        [TestMethod]
        public void TestRemovingTestFromDB()
        {
            Console.WriteLine("Adding test");
            service.AddTest(oneTest);
            Console.WriteLine("Test added");
            
            Console.WriteLine("Removing test");
            service.RemoveTest(oneTest.Name);
            Console.WriteLine("Deleted");

            service.GetOneTest(oneTest.Name);
        }

        [TestMethod]
        public void UpdateTestData()
        {
            Console.WriteLine("Adding test");
            service.AddTest(oneTest);
            Console.WriteLine("Test added");
            Console.WriteLine("Updating test name");
            service.UpdateData(oneTest.Name, "NewTestName");
            Console.WriteLine("Test name updated");

            Console.WriteLine("Updating test question number");
            service.UpdateQuestionsNumber("NewTestName", 5);
            Console.WriteLine("Test question number updated");

            Console.WriteLine("Updating test time for one question");
            service.UpdateTimeForOneQuestion("NewTestName", 40);
            Console.WriteLine("Test time for one question updated");

            Test test = service.GetOneTest("NewTestName");

            Assert.AreEqual(test.Name, "NewTestName", "Names are not equal");
            Assert.AreEqual(test.countLength(), 5, "Number of questions are not equal");
            Assert.AreEqual(test.TimeForOneQuestion, 40, "Times are not equal");
        }

        [TestMethod]
        public void GetTestPercentage()
        {
            Console.WriteLine("Adding test");
            service.AddTest(oneTest);
            Console.WriteLine("Test added");
            Console.WriteLine("Set question number");
            service.UpdateQuestionsNumber("TEST", 5);
            Console.WriteLine("Question number updated");

            Console.WriteLine("Counting percentage of correct answers");
            int percent = service.countPercentages("TEST",4);
            Console.WriteLine("Percentage counted");

            Assert.AreEqual(percent, 80);
        }

        [TestMethod]
        public void TestForUnique()
        {
            Console.WriteLine("Adding test");
            service.AddTest(oneTest);
            Console.WriteLine("Test added");

            Console.Write("Start unique testing...");
            bool first = service.isUnique("TEST");
            Console.Write("Testing finished");

            Assert.AreEqual(first, false, "Logical variables are not equal");
        }
    }
}
