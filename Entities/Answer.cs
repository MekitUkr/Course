using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Answer
    {
        private string answer;
        private bool isRight;
        public string MyAnswer { get=>answer; set=>answer=value; }
        public bool IsRight { get=>isRight; set=>isRight=value; }
        public Answer()
        {

        }

        public Answer(string myAnswer, bool isRight)
        {
            MyAnswer = myAnswer;
            IsRight = isRight;
        }
    }
}
