namespace DataProviderContract
{
    public interface IDataProvider <T>
    {
        string FileType { get; }
        void Write(T data, string connection);
        T Read(string connection);
    }
}
