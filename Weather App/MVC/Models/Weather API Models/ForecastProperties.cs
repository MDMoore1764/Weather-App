using Newtonsoft.Json;
using System;

namespace Weather_App.MVC.Models
{
    public class ForecastProperties
    {
        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("generatedAt")]
        public DateTimeOffset GeneratedAt { get; set; }

        [JsonProperty("updateTime")]
        public DateTimeOffset UpdateTime { get; set; }

        [JsonProperty("validTimes")]
        public string ValidTimes { get; set; }

        [JsonProperty("periods")]
        public Period[] Periods { get; set; }
    }

}
