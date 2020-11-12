using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Weather_App.MVC.Cors;
using Weather_App.MVC.API;

namespace Weather_App.MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowCrossSite]
    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;

        public ForecastController(ILogger<ForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(double latitude, double longitude)
        {
            WeatherAPI weather = new WeatherAPI(latitude, longitude);
            return JsonConvert.SerializeObject(weather.GetForecastAsync().Result);
        }
    }
}