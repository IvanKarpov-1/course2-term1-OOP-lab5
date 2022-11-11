namespace BLL
{
    public class DataStorage
    {
        public Students Students { get; }
        public Managers Managers { get; }
        public McdonaldsWorkers McdonaldsWorkers { get; }

        public DataStorage()
        {
            Students = new Students();
            Managers = new Managers();
            McdonaldsWorkers = new McdonaldsWorkers();
        }
    }
}