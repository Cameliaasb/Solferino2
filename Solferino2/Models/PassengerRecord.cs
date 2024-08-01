using Solferino2.Models.Enums;

namespace Solferino2.Models
{
    public class PassengerRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public DayType Day { get; set; }
        public TimeRange TimeRange { get; set; }
        public int NbOfPassengers { get; set; }
        public required string TrainStationCode { get; set; }
    }
}
