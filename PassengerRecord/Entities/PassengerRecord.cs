using PassengerData.Entities.Enums;

namespace PassengerData.Entities.Entities
{
    public class PassengerRecord
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DayType Day { get; set; }
        public TimeRange TimeRange { get; set; }
        public int NbOfPassengers { get; set; }
        public required string Line { get; set; }
        public required string TrainStationCode { get; set; }
    }
}
