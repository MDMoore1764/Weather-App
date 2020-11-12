using System;
using System.Threading.Tasks;
using Weather_App.MVC.Models;

namespace Weather_App.MVC.API
{
    public class WeatherAPI
    {
        private readonly APIAgent api;
        private readonly Coordinates coordinates;
        private string URIEntryPoint { get => $"https://api.weather.gov/points/{coordinates.Latitude},{coordinates.Longitude}"; }

        public WeatherAPI(double latitude, double longitude)
        {
            api = new APIAgent();
            this.coordinates = new Coordinates(latitude, longitude);
        }

        /// <summary>
        /// Gets forecast for Weather location. If invalid coordinates, it will return null.
        /// </summary>
        /// <returns></returns>
        public async Task<WeatherAPIResponse> GetForecastAsync()
        {
            WeatherAPIResponse response = await api.GetJsonAsync<WeatherAPIResponse>(new Uri(URIEntryPoint));
            if (response == null) return null;
            response.Forecast = await api.GetJsonAsync<Forecast>(response.Properties.ForecastURI);

            return response;

        }


    }
}
