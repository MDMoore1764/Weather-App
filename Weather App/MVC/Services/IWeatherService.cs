using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_App.MVC.Models;

namespace Weather_App.MVC.Services
{
    public interface IWeatherService
    {
        public Task<WeatherAPIResponse> GetForecastAsync(double latitude, double longitude);
    }
}
