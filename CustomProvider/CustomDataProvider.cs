using DataProviderContract;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomProvider
{
    public class CustomDataProvider<T> : IDataProvider<T>
    {
        public string FileType => ".custom";

        public void Write(T data, string connection)
        {
            using (var fs = new FileStream(connection + FileType, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, data);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }

        public T Read(string connection)
        {
            T data;
            using (var fs = new FileStream(connection + FileType, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    data = (T)formatter.Deserialize(fs);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
            return data;
        }
    }
}
