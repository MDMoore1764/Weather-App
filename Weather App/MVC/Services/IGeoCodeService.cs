using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_App.MVC.Models;

namespace Weather_App.MVC.Services
{
    public interface IGeoCodeService
    {
        public Task<Coordinates> GetCoordinatesAsync(string street, string city, string state);

        public Task<Coordinates> GetCoordinatesAsync(string street, string zipcode);

        public Task<Coordinates> GetCoordinatesAsync(Address address);

    }
}
