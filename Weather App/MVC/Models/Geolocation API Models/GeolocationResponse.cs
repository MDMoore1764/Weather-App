using Newtonsoft.Json;

namespace Weather_App.MVC.Models
{
    public class GeolocationResponse
    {
        [JsonProperty("result")]
        public Result GeolocationResult { get; set; }
    }
}
