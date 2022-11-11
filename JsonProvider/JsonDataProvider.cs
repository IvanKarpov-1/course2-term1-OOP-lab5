using DataProviderContract;
using System;
using System.IO;
using System.Text.Json;

namespace JsonProvider
{
    public class JsonDataProvider<T> : IDataProvider<T>
    {
        public string FileType => ".json";

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true
        };


        public void Write(T data, string connection)
        {
            using (var fs = new FileStream(connection + FileType, FileMode.Create))
            {
                try
                {
                     JsonSerializer.Serialize(fs, data, _options);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public T Read(string connection)
        {
            T data;
            using (var fs = new FileStream(connection + FileType, FileMode.OpenOrCreate))
            {
                try
                {
                    data = JsonSerializer.Deserialize<T>(fs, _options);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return data;
        }
    }
}
