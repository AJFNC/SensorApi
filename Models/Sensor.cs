using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace SensorApi.Models
{
    public class Sensor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id {get; set;}
        public string owner {get; set;}
        public string s {get; set;}
        public int p1 {get; set;}
        public int p2 {get; set;}
        public int p3 {get; set;}

    }

    public class SensorContext : DbContext
    {
        public SensorContext(DbContextOptions<SensorContext> options) : base(options)
        {
        }

        public DbSet<Sensor> SensorDatas {get; set;}
    }
}