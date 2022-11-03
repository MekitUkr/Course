using System;

namespace TestLibrary
{
    public class TestUtils
    {
        private string testName;
        private int[] percentages = new int[] { };
        public string TestName { get=>testName; set=>testName=value; }
        public int[] Percentages { get=>percentages; set=>percentages=value; }
        public TestUtils(string TestName, int percent)
        {
            this.TestName = TestName;
            AddToTheEnd(percent);
        }

        private void AddToTheEnd(int percent)
        {
            Array.Resize(ref percentages, percentages.Length + 1);
            percentages[percentages.Length - 1] = percent;
        }

        public void Concat(int[] newarr)
        {
            int[] result = new int[percentages.Length + newarr.Length];
            percentages.CopyTo(result, 0);
            newarr.CopyTo(result, percentages.Length);
            Percentages = result;
        }
    }
}
