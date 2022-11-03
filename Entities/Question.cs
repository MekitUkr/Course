using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Question
    {
        private int numberOfAnswers = 0;
        private Answer[] answers = new Answer[] { };
        private string questionName;
        public int NumberOfAnswers { get=>numberOfAnswers; set=>numberOfAnswers = value; }
        public Answer[] Answers { get=>answers; set=>answers=value; }
        public string QuestionName { get=>questionName; set=>questionName=value; }
        public Question()
        {

        }

        public Question(Answer[] answers, string questionName)
        {
            Answers = answers;
            QuestionName = questionName;
            NumberOfAnswers = answers.Length;
        }

        public int countLength()
        {
            numberOfAnswers = answers.Length;
            return numberOfAnswers;
        }

        public Question(string questionName)
        {
            QuestionName = questionName;
        }

    }
}
