using System;
using DAL;
using Entities;
using IEntityService;
namespace BLL
{
    public class TestEntityService: ITestService
    {
        ITestContext<Test> Context { get; set; }
        public void RemoveTest(string testName)
        {
            Test[] newarr = new Test[] { };
            Test test = Context.SearchData(testName);
            newarr = Context.GetData();
            if (newarr.Length == 0)
            {
                throw new Exception("Empty DB, add some test");
            }
            newarr = Array.FindAll(newarr, c => c.Name != testName);
            Context.SetData(newarr);
        }

        public void UpdateData(string testName, string newTestName)
        {
            try
            {
                Test[] newarr = new Test[] { };
                newarr = Context.GetData();
                Test test = Context.SearchData(testName);
                if (newarr.Length == 0)
                {
                    throw new Exception("Empty DB, add some test");
                }
                foreach (var item in newarr)
                {
                    if (item.Name == testName)
                    {
                        item.Name = newTestName;
                    }
                }
                Context.SetData(newarr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateQuestionsNumber(string testName, int count)
        {
            try
            {
                if (count < 0)
                {
                    throw new Exception("Invalid new count of questions");
                }
                Test[] tests = Context.GetData();
                Test test = Context.SearchData(testName);
                int length = test.countLength();//к-во вопросов в тесте
                Question[] questions = test.Questions;
                Array.Resize(ref questions, count);
                test.Questions = questions;
                if (count > length)
                {
                    int i = 0;
                    foreach (var q in test.Questions)
                    {
                        if (length + i == count)
                        {
                            break;
                        }
                        test.Questions[length + i] = new Question("Mockup question");
                        i++;
                    }
                }
                foreach (var item in tests)
                {
                    if (item.Name == test.Name)
                    {
                        item.Questions = test.Questions;
                        item.countLength();
                    }
                }
                Context.SetData(tests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTimeForOneQuestion(string testName, int newValue)
        {
            try
            {
                if (newValue < 0)
                {
                    throw new Exception("Invalid new time for one question");
                }
                Test[] tests = Context.GetData();
                Test test = Context.SearchData(testName);

                foreach (var item in tests)
                {
                    if (item.Name == test.Name)
                    {
                        item.TimeForOneQuestion = newValue;
                    }
                }
                Context.SetData(tests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Test[] GetAllTests()
        {
            return Context.GetData();
        }

        public Test GetOneTest(string testName)
        {
            return Context.SearchData(testName);
        }

        public void AddTest(Test test)
        {
            Test[] newarr = new Test[] { };
            newarr = Context.GetData();
            Array.Resize(ref newarr, newarr.Length + 1);
            newarr[newarr.Length - 1] = test;
            Context.SetData(newarr);
        }

        public int countPercentages(string testName, int rightAnswersCount)
        {
            try
            {
                Test[] tests = Context.GetData();
                Test test = Context.SearchData(testName);
                double a = (double)rightAnswersCount;
                double b = (double)test.countLength();
                if (test.Questions.Length == 0)
                {
                    return 0;
                }
                if (rightAnswersCount > test.Questions.Length)
                {
                    throw new Exception("Invalid correct answers number");
                }
                foreach (var item in tests)
                {
                    if (item.Name == test.Name)
                    {
                        item.PercentageOfCorrectAnswers = (int)((a / b) * 100);
                    }
                }
                Context.SetData(tests);
                return (int)((a / b) * 100);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool isUnique(string testName)
        {
            Test[] tests = Context.GetData();
            foreach (var item in tests)
            {
                if (item.Name == testName)
                {
                    return false;
                }
            }
            return true;
        }

        public TestEntityService()
        {
            Context = new TestDataContext();
        }
    }
}
