using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Weather_App.MVC.Cors;
using Weather_App.MVC.Services;
using System;

namespace Weather_App.MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowCrossSite]
    public class CoordinateController : ControllerBase
    {
        private readonly IGeoCodeService _geocodeService;
        private readonly ILogger<CoordinateController> _logger;
        public CoordinateController(ILogger<CoordinateController> logger, IGeoCodeService geocodeService)
        {
            _logger = logger;
            _geocodeService = geocodeService;
        }
        [HttpGet]
        public string Get(string street, string city, string state, string zip)
        {
            if(String.IsNullOrEmpty(zip))
            {
                return JsonConvert.SerializeObject(_geocodeService.GetCoordinatesAsync(street, city, state).Result);
            }
            else
            {
                return JsonConvert.SerializeObject(_geocodeService.GetCoordinatesAsync(street, zip).Result);
            }
        }
    }
}