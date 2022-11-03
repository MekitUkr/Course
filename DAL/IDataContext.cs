using System;
using DataProvider;
using JSONProvider;
using Entities;
namespace DAL
{
    public interface ITestContext<T>
    {
        IDataProvider<T> DataProvider { get; set; }
        T[] GetData();
        void SetData(T[] data);
        T SearchData(string name);
    }

    public interface IQuestionContext 
    {
        ITestContext<Test> TestContext { get; set; }
        Question[] GetData(string testName);
        void SetData(string testName, Question[] data);
        Question SearchData(string testName, int questionNumber);
    }

    public interface IAnswerContext
    {
        IQuestionContext QuestionContext { get; set; }
        Answer[] GetData(string testName, int questionNumber);
        void SetData(string testName, int questionNumber, Answer[] answer);
        Answer SearchData(string testName, int questionNumber, int answerNumber);
    } 


}
