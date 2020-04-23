using MyMonkeyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMonkeyApp.Services
{
    public class MonkeyServices
    {
        private HttpClient client;
        public MonkeyServices()
        {
            client = new HttpClient();
        }

        public async Task<List<Monkey>> RefreshDataAsync()
        {
            var items = new List<Monkey>();
            var uri = new Uri("https://mymonkeybackend.azurewebsites.net/monkey");
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Monkey>>(content);
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
