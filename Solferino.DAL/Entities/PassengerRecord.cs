using Solferino.DAL.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Solferino.DAL.Entities
{
    public class PassengerRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DayType Day { get; set; }
        public TimeRange TimeRange { get; set; }
        public int NbOfPassengers { get; set; }
        public required string Line { get; set; }
        public required string TrainStationCode { get; set; }
    }
}
