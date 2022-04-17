using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Threading.Tasks;
using Moga_Stefan_Proiect.Models;
using System.Net.Http;

namespace Moga_Stefan_Proiect.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
    
        string RestUrl = "https://192.168.232.1:45455/api/Pizzas";
        public List<Pizza> Orders { get; private set; }

        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
        }

        public async Task<List<Pizza>> RefreshDataAsync()
        {
            Orders = new List<Pizza>();

            Uri uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Orders = JsonConvert.DeserializeObject<List<Pizza>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Orders;
        }
    }
}
