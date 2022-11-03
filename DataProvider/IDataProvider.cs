using System;

namespace DataProvider
{
    public interface IDataProvider<T>
    {
        void Add(T[] data);
        T[] Read();
    }
}
