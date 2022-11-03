using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary
{
    public class TestStatistic
    {
        private TestUtils[] utils;
        public TestUtils[] Utils { get=>utils; set=>utils = value; }

        public TestStatistic()
        {
            utils = new TestUtils[] { };
        }

        public void AddToTheStatistic(TestUtils obj)
        {
            if (utils.Length == 0)
            {
                AddIfNotExistInUtils(obj);
            }
            else
            {
                AddIfTestAlreadyInUtils(obj);
            }
        }

        private void AddIfNotExistInUtils(TestUtils obj)
        {
            Array.Resize(ref utils, utils.Length + 1);
            utils[utils.Length - 1] = obj;
        }

        private void AddIfTestAlreadyInUtils(TestUtils obj)
        {
            bool isExist = false; ;
            foreach(var item in utils)
            {
                if(item.TestName == obj.TestName)
                {
                    item.Concat(obj.Percentages);
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                AddIfNotExistInUtils(obj);
            }
        }
    }
}
