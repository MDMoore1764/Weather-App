using Newtonsoft.Json;

namespace Weather_App.MVC.Models
{
    public class Forecast
    {
        [JsonProperty("properties")]
        public ForecastProperties Properties { get; set; }
    }
}
