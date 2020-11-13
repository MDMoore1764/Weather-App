using Newtonsoft.Json;
using System;

namespace Weather_App.MVC.Models
{
    public class WeatherProperties
    {
        [JsonProperty("forecast")]
        public Uri ForecastURI { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("relativeLocation")]
        public RelativeLocation Location { get; set; }
    }
}
