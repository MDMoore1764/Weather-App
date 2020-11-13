using Newtonsoft.Json;

namespace Weather_App.MVC.Models
{
    public class RelativeLocationProperties
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State {get; set;}
    }
}
