using Newtonsoft.Json;
using RestAPI.Model;
using System.Reflection;
using System.Text;

namespace RestAPI.Data
{
    public static class MeteoriteLandingData
    {
        static string meteoriteLandingsJson;
        public static string MeteoriteLandingsJson
        {
            get
            {
                if (meteoriteLandingsJson == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceStream = assembly.GetManifestResourceStream("RestAPI.Data.MeteoriteLandings.json");

                    using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
                    {
                        meteoriteLandingsJson = reader.ReadToEnd();
                    }
                }
                return meteoriteLandingsJson;
            }
        }

        static List<MeteoriteLanding> restMeteoriteLandings;
        public static List<MeteoriteLanding> RestMeteoriteLandings
        {
            get
            {
                if (restMeteoriteLandings == null)
                {
                    restMeteoriteLandings = JsonConvert.DeserializeObject<List<MeteoriteLanding>>(MeteoriteLandingsJson);
                }
                return restMeteoriteLandings;
            }
        }
    }
}
