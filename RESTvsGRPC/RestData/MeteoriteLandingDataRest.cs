using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace RESTvsGRPC.RestData
{
    public static class MeteoriteLandingDataRest
    {
        static string meteoriteLandingsJson;
        public static string MeteoriteLandingsJson
        {
            get
            {
                if (meteoriteLandingsJson == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceStream = assembly.GetManifestResourceStream("RESTvsGRPC.RestData.MeteoriteLandings.json");

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
