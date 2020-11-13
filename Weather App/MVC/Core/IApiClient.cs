using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_App.MVC.Core
{
    public interface IApiClient
    {
        public Task<T> GetJsonAsync<T>(Uri entryPoint);
    }
}
