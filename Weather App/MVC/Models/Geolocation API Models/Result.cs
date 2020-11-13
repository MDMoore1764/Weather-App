using Newtonsoft.Json;

namespace Weather_App.MVC.Models
{
    public class Result
    {
        [JsonProperty("addressMatches")]
        public AddressMatch[] GeolocationAddressMatches { get; set; }
    }
}
