using DataProviderContract;
using System;
using System.IO;

namespace DAL
{
    public class EntityContext<T> : IEntityContext<T>
    {
        public string Connection { get; }
        public IDataProvider<T> DataProvider { get; set; }

        private T _data;

        public EntityContext(string connection)
        {
            Connection = connection;
        }

        public T GetData()
        {
            if (DataProvider == null) return default;
            if (_data != null) return _data;
            try
            {
                _data = DataProvider.Read(Connection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _data;
        }

        public void SetData(T data)
        {
            if (DataProvider == null) return;
            try
            {
                DataProvider.Write(data, Connection);
                _data = data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteFile()
        {
            if (DataProvider == null) return;
            try
            {
                File.Delete(Connection + DataProvider.FileType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
