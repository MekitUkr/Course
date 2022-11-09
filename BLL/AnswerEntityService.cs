using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;
using IEntityService;
namespace BLL
{
    public class AnswerEntityService:IAnswerService
    {
        IAnswerContext Context { get; set; }
        public void AddAnswer(string testName,int questionNumber, Answer answer)
        {
            try
            {
                Answer[] answers = Context.GetData(testName, questionNumber);
                Array.Resize(ref answers, answers.Length + 1);
                answers[answers.Length - 1] = answer;
                Context.SetData(testName, questionNumber,answers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Answer[] GetAllAnswersForQuestion(string testName, int questionNumber)
        {
            try
            {
                return Context.GetData(testName, questionNumber);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Answer GetOneAnswerForQuestion(string testName, int questionNumber,int answerNumber)
        {
            return Context.SearchData(testName, questionNumber, answerNumber);
        }

        public void RemoveData(string testName, int questionNumber, int answerNumber)
        {
            try
            {
                int index = answerNumber - 1;
                Answer[] answers = Context.GetData(testName, questionNumber);
                if (index < 0 || index > answers.Length - 1)
                {
                    throw new IndexOutOfRangeException("Incorrect answer number");
                }
                for (int i = index; i < answers.Length - 1; i++)
                {
                    answers[i] = answers[i + 1];
                }
                Array.Resize(ref answers, answers.Length - 1);

                Context.SetData(testName, questionNumber, answers);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateData(string testName, int questionNumber, int answerNumber, string newAnswerName, bool isRight)
        {
            try
            {
                Answer[] answers = Context.GetData(testName, questionNumber);
                Answer answer = Context.SearchData(testName, questionNumber, answerNumber);
                if (answers.Length == 0)
                {
                    throw new IndexOutOfRangeException("No answers for this question");
                }
                foreach (var a in answers)
                {
                    if (a.MyAnswer == answer.MyAnswer)
                    {
                        a.MyAnswer = newAnswerName;
                        a.IsRight = isRight;
                    }
                }
                Context.SetData(testName, questionNumber, answers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         * @param answerNumber - номер того ответа который выбрал пользователь
         * @param questionNumber - номер вопроса, на который ответил пользователь
         */
        public bool CheckAnswer(string testName, int questionNumber, int answerNumber)
        {
            
            Answer answer = Context.SearchData(testName, questionNumber, answerNumber);
            return answer.IsRight;
        }

        public AnswerEntityService()
        {
            Context = new AnswerEntityContext();
        }
    }
}
