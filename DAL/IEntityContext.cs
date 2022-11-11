using DataProviderContract;

namespace DAL
{
    public interface IEntityContext<T>
    {
        string Connection { get; }
        IDataProvider<T> DataProvider { get; }
        T GetData();
        void SetData(T data);
        void DeleteFile();
    }
}
