using APIGraphQL.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGraphQL.Services
{
    public class ChampionService : IChampionService
    {
        private readonly HttpClient _client;
        public ChampionService(HttpClient client, IConfiguration config)
        {
            _client = client;
        }

        public async Task<Champion> GetAsync(string name)
        {
            var response = await _client.GetAsync(
                QueryHelpers.AddQueryString($"http://api-lol.herokuapp.com/api/champions/{name}", new Dictionary<string, string>())
            );

            return JsonConvert.DeserializeObject<Champion>(await response.Content.ReadAsStringAsync());
        }
    }
}
