using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    public class CityLocation
    {
        [Key]
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
