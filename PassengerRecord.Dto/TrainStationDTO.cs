namespace PassengerData.Dto
{
    public class TrainStationDTO
    {
        public required string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int NbOfPassengers { get; set; }

        public required List<string> Lines { get; set; }
    }
}
