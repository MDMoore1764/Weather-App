using Weather_App.MVC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_App.MVC.API
{
    public static class GeoCodeAPI
    {
        private static readonly APIAgent api = new APIAgent();
        public static async Task<Coordinates> GetCoordinatesAsync(string street, string city, string state)
        {
            Address address = new Address(street, city, state);
            return await GetCoordinatesAsync(address);
        }
        public static async Task<Coordinates> GetCoordinatesAsync(string street, string zipcode)
        {
            Address address = new Address(street, zipcode);
            return await GetCoordinatesAsync(address);
        }
        public static async Task<Coordinates> GetCoordinatesAsync(Address address)
        {
            Uri uri = GetEntryPoint(address);
            var response = await api.GetJsonAsync<GeolocationResponse>(uri);
            if (response == null || response.Result.AddressMatches.Length == 0) return null;

            return response.Result.AddressMatches.First().Coordinates;

        }

        private static Uri GetEntryPoint(Address address)
        {
            return new Uri($"https://geocoding.geo.census.gov/geocoder/locations/address?street={address.StreetNumberAndName}&city={address.City}&state={address.State}&zip={address.Zip}&benchmark=4&format=json");
        }


    }
}
