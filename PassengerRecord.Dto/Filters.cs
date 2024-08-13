namespace PassengerData.Dto
{
    public class Filters
    {
        public string Line { get; set; } = string.Empty;
        public int? Year { get; set; }
        public int? Day { get; set; }
        public int? TimeRange { get; set; }
    }
}
