using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Weather_App.MVC.Cors;
using Weather_App.MVC.Services;

namespace Weather_App.MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowCrossSite]
    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;
        private readonly IWeatherService _weatherService;
        public ForecastController(ILogger<ForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }
        [HttpGet]
        public string Get(double latitude, double longitude)
        {
            return JsonConvert.SerializeObject(_weatherService.GetForecastAsync(latitude, longitude).Result);
        }
    }
}