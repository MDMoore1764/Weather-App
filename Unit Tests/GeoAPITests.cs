using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather_App.MVC.Core;
using Weather_App.MVC.Models;
using Weather_App.MVC.Services;

namespace UnitTests
{
    [TestClass]
    public class GeoAPITests
    {
        public static IApiClient client = new ApiClient();
        /* Requirements:
   * 
   * Geo API should take either a street with city and state OR a zipcode and return coordinates
   * API should handle invalid address, cities, and states, or zipcodes and return null.
   */
        [TestMethod]
        public void ValidStreetCityState()
        {

            Coordinates coords = new GeoCodeService(client).GetCoordinatesAsync("20338 Progress Dr", "Strongsville", "Ohio").Result;
            Assert.IsNotNull(coords);
            Assert.IsTrue(coords.Longitude <= 180 && coords.Longitude > -180);
            Assert.IsTrue(coords.Latitude <= 90 && coords.Latitude >= -90);
        }
        [TestMethod]
        public void InValidStreetCityState()
        {
            Coordinates coords = new GeoCodeService(client).GetCoordinatesAsync("5555555 MadeUp Drive", "DefinitelyNotACity", "NotAState").Result;
            Assert.IsNull(coords);
        }

        [TestMethod]
        public void ValidStreetZip()
        {
            Coordinates coords = new GeoCodeService(client).GetCoordinatesAsync("20338 Progress Dr", "44149").Result;
            Assert.IsNotNull(coords);
            Assert.IsTrue(coords.Longitude <= 180 && coords.Longitude > -180);
            Assert.IsTrue(coords.Latitude <= 90 && coords.Latitude >= -90);
        }
        [TestMethod]
        public void InValidStreetZip()
        {
            Coordinates coords = new GeoCodeService(client).GetCoordinatesAsync("5555555 MadeUp Drive", "1111119999").Result;
            Assert.IsNull(coords);
        }

    }
}
