using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataProvider;
using JSONProvider;

namespace DAL
{
    public class AnswerEntityContext: IAnswerContext
    {
        public IQuestionContext QuestionContext { get; set; }

        public Answer[] GetData(string testName, int questionNumber)
        {
            Question question = QuestionContext.SearchData(testName, questionNumber);
            Answer[] answers = question.Answers;
            return answers;
        }

        public Answer SearchData(string testName, int questionNumber, int answerNumber)
        {
            try
            {
                Answer[] answers = GetData(testName, questionNumber);
                if(answerNumber < 1 || answerNumber > answers.Length)
                {
                    throw new Exception("Incorrect answerNumber");
                }
                return answers[answerNumber - 1];
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void SetData(string testName,int questionNumber, Answer[] answers)
        {
            try
            {
                Question question = QuestionContext.SearchData(testName, questionNumber);
                Question[] questions = QuestionContext.GetData(testName);
                if (questionNumber < 1 || questionNumber > questions.Length)
                {
                    throw new IndexOutOfRangeException("Invalid question number");
                }
                int i = 0;
                foreach (var q in questions)
                {
                    if (i == questionNumber - 1)
                    {
                        questions[i].Answers = answers;
                    }
                    i++;
                }
                QuestionContext.SetData(testName, questions);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public AnswerEntityContext()
        {
            QuestionContext = new QuestionEntityContext();
        }
    }
}
