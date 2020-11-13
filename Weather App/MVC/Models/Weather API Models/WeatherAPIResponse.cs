using Newtonsoft.Json;

namespace Weather_App.MVC.Models
{
    public class WeatherAPIResponse
    {
        [JsonProperty("properties")]
        public WeatherProperties Properties { get; set; }
        public Forecast Forecast { get; set; }
    }
}
