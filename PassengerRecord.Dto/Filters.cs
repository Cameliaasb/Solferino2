using System.ComponentModel.DataAnnotations;

namespace PassengerData.Dto
{
    public class Filters
    {
        [Required(AllowEmptyStrings = false)]
        public string Line { get; set; } = string.Empty;
        [Required]
        public int Year { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        public int TimeRange { get; set; }
    }
}
