using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Weather_App.MVC.Cors;
using Weather_App.MVC.API;
using System;

namespace Weather_App.MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowCrossSite]
    public class CoordinateController : ControllerBase
    {
        private readonly ILogger<CoordinateController> _logger;

        public CoordinateController(ILogger<CoordinateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string street, string city, string state, string zip)
        {
            if(String.IsNullOrEmpty(zip))
            {
                return JsonConvert.SerializeObject(GeoCodeAPI.GetCoordinatesAsync(street, city, state).Result);
            }
            else
            {
                return JsonConvert.SerializeObject(GeoCodeAPI.GetCoordinatesAsync(street, zip).Result);
            }
        }



    }
}