using System;
using System.Collections.Generic;
using System.Text;
using DataProvider;
using Entities;
using JSONProvider;
namespace DAL
{
    public class TestDataContext : ITestContext<Test>
    {
        public IDataProvider<Test> DataProvider { get; set; }
        public Test[] GetData()
        {
            try
            {
                if(DataProvider == null)
                {
                    throw new Exception("Uninitialized DataProvider");
                }
                return DataProvider.Read();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void SetData(Test[] data)
        {
            foreach(var item in data)
            {
                item.countLength();
            }
            DataProvider.Add(data);
        }
        public Test SearchData(string name)
        {
            try
            {
                Test[] newarr = new Test[] { };
                newarr = DataProvider.Read();
                newarr = Array.FindAll(newarr, c => c.Name == name);
                if (newarr.Length == 0)
                {
                    throw new Exception("Cannot find this test");
                }
                Test test = newarr[0];
                return test;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public TestDataContext()
        {
            DataProvider = new JSONDataProvider<Test>();
        }
    }
}
