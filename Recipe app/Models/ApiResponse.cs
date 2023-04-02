using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Recipe_app.Models
{
    public class ApiResponse : IApiResponse
    {
        string _uri { get; set; }
        public string _print { get; set; }


        private JsonDocument _json { get; set; }
        public async Task<JsonDocument> GetRecipe(string uri)
        {

            _uri = uri;
            var baseUri = "https://tasty.p.rapidapi.com/recipes/";
            var client = new HttpClient();
            try
            {

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{baseUri}{_uri}"),
                    Headers =
    {
        { "X-RapidAPI-Key", "81d5efb480mshce643f0fbc0cd10p1ad05ejsnf93405f1436d" },
        { "X-RapidAPI-Host", "tasty.p.rapidapi.com" },
    },

                };
                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();

                _json = JsonDocument.Parse(body);

            }
            catch (HttpRequestException)
            {
                _print = "Please turn on the internet!";
            }

            return _json;
        }


    }
}