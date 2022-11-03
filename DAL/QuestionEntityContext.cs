using System;
using System.Collections.Generic;
using System.Text;
using DataProvider;
using Entities;
using JSONProvider;

namespace DAL
{
    public class QuestionEntityContext:IQuestionContext
    {
        public ITestContext<Test> TestContext { get; set; }

        public Question[] GetData(string testName)
        {
            try
            {
                Test test = TestContext.SearchData(testName);
                Question[] questions = new Question[] { };
                questions = test.Questions;
                return questions;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Question SearchData(string testName,int questionNumber)
        {
            try
            {
                Test test = TestContext.SearchData(testName);
                Question[] questions = new Question[] { };
                questions = test.Questions;
                if(questionNumber < 1 || questionNumber > questions.Length)
                {
                    throw new IndexOutOfRangeException("Incorrect question number");
                }
                return questions[questionNumber - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetData(string testName,Question[] data)
        {
            try
            {
                Test test = TestContext.SearchData(testName);
                Test[] tests = TestContext.GetData();
                foreach (var item in data)
                {
                    item.countLength();
                }
                foreach (var item in tests)
                {
                    if(item.Name == test.Name)
                    {
                        item.Questions = data;
                        break;
                    }
                }
                TestContext.SetData(tests);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public QuestionEntityContext()
        {
            TestContext = new TestDataContext();
        }
    }
}
