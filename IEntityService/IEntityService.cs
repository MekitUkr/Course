using System;
using DAL;
using Entities;
namespace IEntityService
{
    public interface ITestService 
    {
        public void RemoveTest(string testName);
        public void UpdateData(string testName, string newTestName);
        public void UpdateQuestionsNumber(string testName, int count);
        public void UpdateTimeForOneQuestion(string testName, int newValue);
        public Test[] GetAllTests();
        public Test GetOneTest(string testName);
        public void AddTest(Test test);
        public int countPercentages(string testName, int rightAnswersCount);
        public bool isUnique(string testName);
    }

    public interface IQuestionService 
    {
        public void AddQuestion(string testName, Question data);
        public void RemoveData(string testName, int numberOfQuestion);
        public void UpdateData(string testName, int questionNumber, string newQuestionName);
        public Question[] getAllQuestionsForTest(string testName);
        public Question GetOneQuestionForTest(string testName, int questionNumber);
    }


    public interface IAnswerService
    {
        public void AddAnswer(string testName, int questionNumber, Answer answer);
        public Answer[] GetAllAnswersForQuestion(string testName, int questionNumber);
        public Answer GetOneAnswerForQuestion(string testName, int questionNumber, int answerNumber);
        public void RemoveData(string testName, int questionNumber, int answerNumber);
        public void UpdateData(string testName, int questionNumber, int answerNumber, string newAnswerName, bool isRight);
        public bool CheckAnswer(string testName, int questionNumber, int answerNumber);
    }


}
