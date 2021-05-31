using Application.DTO;
using Application.Interfaces.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Api
{
    public class JsonPlaceHolderTypicodeCom : IAsigneeAPI
    {
        static HttpClient client;
        public JsonPlaceHolderTypicodeCom()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public IEnumerable<AsigneeDTO> GetAll()
        {
            return GetAsigneesAsync("users").Result;
        }

        static async Task<List<AsigneeDTO>> GetAsigneesAsync(string path)
        {
            String responseBody = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<List<AsigneeDTO>>(responseBody);
        }
    }
}
