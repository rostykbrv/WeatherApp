using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        [Key]
        public int Id { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime TimeRecorded { get; set; }
    }
}
