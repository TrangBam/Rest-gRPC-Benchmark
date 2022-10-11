using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace GrpcAPI.Data
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
                    var resourceStream = assembly.GetManifestResourceStream("GrpcAPI.Data.MeteoriteLandings.json");

                    using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
                    {
                        meteoriteLandingsJson = reader.ReadToEnd();
                    }
                }
                return meteoriteLandingsJson;
            }
        }

        static List<MeteoriteLanding> grpcMeteoriteLandings;
        public static List<MeteoriteLanding> GrpcMeteoriteLandings
        {
            get
            {
                if (grpcMeteoriteLandings == null)
                {
                    grpcMeteoriteLandings = JsonConvert.DeserializeObject<List<MeteoriteLanding>>(MeteoriteLandingsJson, new ProtobufJsonConvertor());
                }
                return grpcMeteoriteLandings;
            }
        }

        static MeteoriteLandingList grpcMeteoriteLandingList;
        public static MeteoriteLandingList GrpcMeteoriteLandingList
        {
            get
            {
                if (grpcMeteoriteLandingList == null)
                {
                    grpcMeteoriteLandingList = new MeteoriteLandingList();
                    grpcMeteoriteLandingList.MeteoriteLandings.AddRange(GrpcMeteoriteLandings);
                }
                return grpcMeteoriteLandingList;
            }
        }
    }
}
