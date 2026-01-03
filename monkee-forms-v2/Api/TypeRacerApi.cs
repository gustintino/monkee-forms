using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace monkee_forms_v2.Api.TypeRacerApi
{
    // just a helper for parsing the appsettings.json
    class Config
    {
        public string ApiKey { get; set; } = "";
    }

    public class TypeRacerApi
    {
        private readonly HttpClient _client;

        public TypeRacerApi(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://data.typeracer.com/api/");

            // hate this but whatever
            // maybe load into config or whatever the fuck
            var json = File.ReadAllText("../../../appsettings.json");
            var apiKey = JsonSerializer.Deserialize<Config>(json)!.ApiKey;

            var header = Base64Encode(apiKey);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", header);
        }

        public async Task<string> GetTextAsync()
        {
            var response = await _client.GetAsync("v1/texts/388");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
 
        private static string Base64Encode(string plainText) 
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

    }
} 