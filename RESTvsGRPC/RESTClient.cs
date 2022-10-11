using Newtonsoft.Json;
using RESTvsGRPC.RestData;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RESTvsGRPC
{
    public class RESTClient
    {
        private static readonly HttpClient client = new();

        public async Task<string> GetSmallPayloadAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await client.GetStringAsync("https://localhost:7203/api/MeteoriteLandings");
        }

        public async Task<List<MeteoriteLanding>> GetLargePayloadAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string meteoriteLandingsString = await client.GetStringAsync("https://localhost:7203/api/MeteoriteLandings/LargePayload");

            return JsonConvert.DeserializeObject<List<MeteoriteLanding>>(meteoriteLandingsString);
        }

        public async Task<string> PostLargePayloadAsync(List<MeteoriteLanding> meteoriteLandings)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("https://localhost:7203/api/MeteoriteLandings/LargePayload", meteoriteLandings);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
