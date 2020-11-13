using Newtonsoft.Json;


namespace Weather_App.MVC.Models
{
    public class AddressMatch
    {
        [JsonProperty("coordinates")]
        public Coordinates GeolocationCoordinates { get; set; }
    }
}
