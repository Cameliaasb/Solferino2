using System.Collections.ObjectModel;

namespace Solferino.DAL.Entities
{
    public class TrainStation
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public Collection<PassengerRecord> PassengerRecords { get; set; } = new Collection<PassengerRecord>();
    }
}
