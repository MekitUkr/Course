using System;
using DataProvider;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace JSONProvider
{
    public class JSONDataProvider<T> : IDataProvider<T>
    {
        private string TestPath = "JSONTests.json";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        public async void Add(T[] data)
        {
            FileStream fs = new FileStream(TestPath, FileMode.Create, FileAccess.Write);
            await JsonSerializer.SerializeAsync<T[]>(fs, data, options);
            fs.Close();
        }

        private async Task<T[]> GetData()
        {
            try
            {
                using (FileStream fs = new FileStream(TestPath, FileMode.OpenOrCreate))
                {
                    T[] arr = await JsonSerializer.DeserializeAsync<T[]>(fs);
                    return arr;
                }
            } catch (Exception ex)
            {
                return new T[] { };
            }
        }

        public T[] Read()
        {
            T[] arr = GetData().Result;
            return arr;
        }
    }
}
