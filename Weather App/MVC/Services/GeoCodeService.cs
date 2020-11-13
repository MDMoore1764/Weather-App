using Weather_App.MVC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Weather_App.MVC.Core;

namespace Weather_App.MVC.Services
{
    public class GeoCodeService : IGeoCodeService
    {
        private IApiClient _apiClient;
        public GeoCodeService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<Coordinates> GetCoordinatesAsync(string street, string city, string state)
        {
            Address address = new Address(street, city, state);
            return await GetCoordinatesAsync(address);
        }
        public async Task<Coordinates> GetCoordinatesAsync(string street, string zipcode)
        {
            Address address = new Address(street, zipcode);
            return await GetCoordinatesAsync(address);
        }
        public async Task<Coordinates> GetCoordinatesAsync(Address address)
        {
            Uri uri = GetEntryPoint(address);
            var response = await _apiClient.GetJsonAsync<GeolocationResponse>(uri);

            if (response == null || response.GeolocationResult.GeolocationAddressMatches.Length == 0)
            {
                return null;
            }

            return response.GeolocationResult.GeolocationAddressMatches.First().GeolocationCoordinates;
        }

        private Uri GetEntryPoint(Address address)
        {
            return new Uri($"https://geocoding.geo.census.gov/geocoder/locations/address?street={address.StreetNumberAndName}&city={address.City}&state={address.State}&zip={address.Zip}&benchmark=4&format=json");
        }
    }
}
