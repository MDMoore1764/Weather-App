using Newtonsoft.Json;


namespace Weather_App.MVC.Models
{
    public partial class GeolocationResponse
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
    public partial class Result
    {

        [JsonProperty("addressMatches")]
        public AddressMatch[] AddressMatches { get; set; }
    }

    public partial class AddressMatch
    {
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
    }

}
