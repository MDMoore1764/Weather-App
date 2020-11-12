using Newtonsoft.Json;
using System;

namespace Weather_App.MVC.Models
{

    public class WeatherAPIResponse
    {
        [JsonProperty("properties")]
        public WeatherProperties Properties { get; set; }
        public Forecast Forecast { get; set; }
    }

    public class WeatherProperties
    {
        [JsonProperty("forecast")]
        public Uri ForecastURI { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("relativeLocation")]
        public RelativeLocation Location { get; set; }
    }

    public class RelativeLocation
    {
        [JsonProperty("properties")]
        public RelativeLocationProperties Properties { get; set; }
    }

    public class RelativeLocationProperties
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State {get; set;}
    }

    public class Forecast
    {
        [JsonProperty("properties")]
        public ForecastProperties Properties { get; set; }
    }

    public partial class ForecastProperties
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


    public partial class Period
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("startTime")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTimeOffset EndTime { get; set; }

        [JsonProperty("isDaytime")]
        public bool IsDaytime { get; set; }

        [JsonProperty("temperature")]
        public long Temperature { get; set; }

        [JsonProperty("temperatureUnit")]
        public TemperatureUnit TemperatureUnit { get; set; }

        [JsonProperty("temperatureTrend")]
        public object TemperatureTrend { get; set; }

        [JsonProperty("windSpeed")]
        public string WindSpeed { get; set; }

        [JsonProperty("windDirection")]
        public string WindDirection { get; set; }

        [JsonProperty("icon")]
        public Uri Icon { get; set; }

        [JsonProperty("shortForecast")]
        public string ShortForecast { get; set; }

        [JsonProperty("detailedForecast")]
        public string DetailedForecast { get; set; }
    }
    public enum TemperatureUnit { F, C };

}
