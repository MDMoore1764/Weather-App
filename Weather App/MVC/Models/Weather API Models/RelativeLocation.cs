using Newtonsoft.Json;

namespace Weather_App.MVC.Models
{
    public class RelativeLocation
    {
        [JsonProperty("properties")]
        public RelativeLocationProperties Properties { get; set; }
    }

}
