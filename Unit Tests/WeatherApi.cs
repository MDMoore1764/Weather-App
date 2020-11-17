using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Weather_App.MVC.Core;
using Weather_App.MVC.Models;
using Weather_App.MVC.Services;

namespace UnitTests
{
    [TestClass]
    public class WeatherAPIUnitTests
    {
        public static IApiClient client = new ApiClient();
        /* Requirements:
    * 
    * API must generate forecast reports for valid coords with non-null properties.
    * Must handle invalid coordinates by returning null.
    */
        [TestMethod]
        public void GetForecastFromValidCoords()
        {
            WeatherService weather = new WeatherService(client);
            Forecast forecast = weather.GetForecastAsync(39.7456, -97.0892).Result.Forecast;
            Assert.IsNotNull(forecast.Properties);
        }

        [TestMethod]
        public void GetForecastFromInValidCoords()
        {
            WeatherService weather = new WeatherService(client);
            WeatherAPIResponse response = weather.GetForecastAsync(10000, -900).Result;

            Assert.IsNull(response);

        }



    }

}
