using Newtonsoft.Json;


namespace Weather_App.MVC.Models
{
    public class Coordinates
    {
        private const int LatMin = -90;
        private const int LatMax = 90;
        private const int LongMin = -180;
        private const int LongMax = 180;

        private double _latitude;

        [JsonProperty("x")]
        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                //Confine Latitude
                if (value < LatMin)
                {
                    _latitude = LatMin;
                }
                else if (value > LatMax)
                {
                    _latitude = LatMax;
                }
                else
                {
                    _latitude = value;
                }

            }
        }
        private double _longitude;

        [JsonProperty("y")]
        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                //Confine Longitude
                if (value < LongMin)
                {
                    _longitude = LongMin;
                }
                else if (value > LongMax)
                {
                    _longitude = LongMax;
                }
                else
                {
                    _longitude = value;
                }
            }
        }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
