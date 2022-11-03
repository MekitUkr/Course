using System;

namespace Entities
{
    [Serializable]
    public class Test
    {
        private string name;
        private int numberOfQuestions=0;
        private int percentageOfCorrectAnswers = 0;
        private int timeForOneQuestion = 10;
        private Question[] questions = new Question[] { };
        public string Name { get=>name; set=>name =value; }
        public int NumberOfQuestions { get=>numberOfQuestions; set=>numberOfQuestions=value; }
        public int PercentageOfCorrectAnswers { get=>percentageOfCorrectAnswers; set=>percentageOfCorrectAnswers=value; }
        public Question[] Questions { get=>questions; set=>questions=value; }
        public int TimeForOneQuestion { get=>timeForOneQuestion; set=>timeForOneQuestion=value; }
        public int countLength()
        {
            numberOfQuestions = questions.Length;
            return numberOfQuestions;
        }
        public Test()
        {

        }

        public Test(string name, Question[] questions)
        {
            Name = name;
            Questions = questions;
            numberOfQuestions = questions.Length;
        }

        public Test(string name)
        {
            Name = name;
        }
    }
}
