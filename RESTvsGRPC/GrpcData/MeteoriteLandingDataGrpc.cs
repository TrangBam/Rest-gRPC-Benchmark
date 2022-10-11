using GrpcAPI;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace RESTvsGRPC.GrpcData
{
    public static class MeteoriteLandingDataGrpc
    {
        static string meteoriteLandingsJson;
        public static string MeteoriteLandingsJson
        {
            get
            {
                if (meteoriteLandingsJson == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceStream = assembly.GetManifestResourceStream("RESTvsGRPC.GrpcData.MeteoriteLandings.json");

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
