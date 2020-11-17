using System;
using System.Threading.Tasks;
using Weather_App.MVC.Models;
using Weather_App.MVC.Core;

namespace Weather_App.MVC.Services
{
    public class WeatherService : IWeatherService
    {
        private IApiClient _apiClient;
        public WeatherService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        /// <summary>
        /// Gets forecast for Weather location. If invalid coordinates, it will return null.
        /// </summary>
        /// <returns></returns>
        public async Task<WeatherAPIResponse> GetForecastAsync(double latitude, double longitude)
        {
            string uriEntryPoint = $"https://api.weather.gov/points/{latitude},{longitude}";
            WeatherAPIResponse response = await _apiClient.GetJsonAsync<WeatherAPIResponse>(new Uri(uriEntryPoint));
            if (response == null) return null;
            Console.WriteLine("Lat: " + latitude + "Long: " + longitude);
            Console.WriteLine("URL: " + response.Properties.ForecastURI);
            response.Forecast = await _apiClient.GetJsonAsync<Forecast>(response.Properties.ForecastURI);
            return response;
        }
    }
}
