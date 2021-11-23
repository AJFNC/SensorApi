namespace SensorApi.Models
{
    public class SensorsDbDatabaseSettings : ISensorsDbDatabaseSettings
    {
        public string SensorsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
    public interface ISensorsDbDatabaseSettings
    {
        string SensorsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
    
}