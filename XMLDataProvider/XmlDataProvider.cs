using DataProviderContract;
using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLDataProvider
{
    public class XmlDataProvider<T> : IDataProvider<T>
    {
        public string FileType => ".xml";

        public void Write(T data, string connection)
        {
            using (var fs = new FileStream(connection + FileType, FileMode.OpenOrCreate))
            {
                var formatter = new XmlSerializer(data.GetType());
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
                var formatter = new XmlSerializer(typeof(T));
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
