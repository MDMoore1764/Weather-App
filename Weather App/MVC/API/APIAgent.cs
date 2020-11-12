﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Weather_App.MVC.API
{
    public class APIAgent
    {
        private HttpClient Client;

        public APIAgent()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/geo+json,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en - US,en; q = 0.9");
            Client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36");
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "UTF-8");
            Client.DefaultRequestHeaders.Connection.Add("keep-alive");
        }

        /// <summary>
        /// Returns empty string if access is denied for any reason.
        /// </summary>
        /// <param name="entryPoint"></param>
        /// <returns></returns>
        public async Task<T> GetJsonAsync<T>(Uri entryPoint)
        {
            var response = await Client.GetAsync(entryPoint);
            
            //check to make sure response code is OK.
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                return data;
            }
            else
            {
                return default;
            }
        }
    }
}
