using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;

namespace BLL
{
    public class QuestionEntityService
    {
        IQuestionContext Context { get; set; }

        public void AddQuestion(string testName, Question data)
        {
            try
            {
                Question[] questions = new Question[] { };
                questions = Context.GetData(testName);
                Array.Resize(ref questions, questions.Length + 1);
                questions[questions.Length - 1] = data;
                Context.SetData(testName,questions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveData(string testName, int numberOfQuestion)
        {
            try
            {
                int index = numberOfQuestion - 1;
                Question[] questions = new Question[] { };
                questions = Context.GetData(testName);
                if (index < 0 || index > questions.Length - 1)
                {
                    throw new IndexOutOfRangeException("Incorrect question number");
                }

                for (int i = index; i < questions.Length - 1; i++)
                {
                    questions[i] = questions[i + 1];
                }
                Array.Resize(ref questions, questions.Length - 1);
                
                Context.SetData(testName,questions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateData(string testName, int questionNumber, string newQuestionName)
        {
            try
            {
                Question[] questions = new Question[] { };
                questions = Context.GetData(testName);
                if (questions.Length == 0)
                {
                    throw new IndexOutOfRangeException($"No questions in {testName} test");
                }
                int i = 0;
                foreach (var q in questions)
                {
                    if (i == questionNumber - 1)
                    {
                        questions[i].QuestionName = newQuestionName;
                    }
                    i++;
                }
               
                Context.SetData(testName,questions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Question[] getAllQuestionsForTest(string testName)
        {
            try
            {
                return Context.GetData(testName);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Question GetOneQuestionForTest(string testName,int questionNumber)
        {
            try
            {
                return Context.SearchData(testName, questionNumber);
            }catch(Exception ex)
            {
                throw ex as Exception;
            }
        }

        public QuestionEntityService()
        {
            Context = new QuestionEntityContext();
        }
    }
}
