using Microsoft.EntityFrameworkCore;
using monkee_forms_v2.Data;
using monkee_forms_v2.Models;
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
            try
            {
                var json = File.ReadAllText("../../../appsettings.json");
                var apiKey = JsonSerializer.Deserialize<Config>(json)!.ApiKey;

                var header = Base64Encode(apiKey);
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", header); 
            }
            catch
            {
                MessageBox.Show("Trouble getting api key.");
            }
        }

        // a default query for testing purposes, should not be actually used
        public async Task<Text> GetTextAsync()
        {
            var response = await _client.GetAsync("v1/texts/388");
            response.EnsureSuccessStatusCode();

            var resTxt = await response.Content.ReadAsStringAsync(); 
            var resParsed = JsonSerializer.Deserialize<TextResponse>(resTxt);

            var textobj = await AddTextAsync(resParsed);
            return textobj;
        }
        
        public async Task<Text> GetTextAsync(int id)
        {
            var response = await _client.GetAsync($"v1/texts/{id}");
            response.EnsureSuccessStatusCode();

            var resTxt = await response.Content.ReadAsStringAsync(); 
            var resParsed = JsonSerializer.Deserialize<TextResponse>(resTxt);

            var textobj = await AddTextAsync(resParsed);
            return textobj; 
        }
 
        private static string Base64Encode(string plainText) 
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private static async Task<Text> AddTextAsync(TextResponse newText)
        {
            using var db = MonkeeFormsDbContextFactory.Create();

            Text? existing = await db.Texts.SingleOrDefaultAsync(t => t.ID == newText.data.tid);

            if (existing == null)
            {
                var tempText = new Text
                {
                    ID = newText.data.tid,
                    TextContent = newText.data.text,
                    Title = newText.data.title,
                    Length = newText.data.length,
                    Type = newText.data.type
                }; 

                db.Add<Text>(tempText);
                await db.SaveChangesAsync();
                return tempText;
            }
            else
            {
                return existing;
            } 
        } 
    }
} 