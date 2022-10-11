using Grpc.Core;
using Grpc.Net.Client;
using GrpcAPI;
using static GrpcAPI.MeteoriteLandings;

namespace RESTvsGRPC
{
    public class GRPCClient
    {
        private readonly MeteoriteLandingsClient client;

        public GRPCClient()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7256");
            client = new MeteoriteLandingsClient(channel);
        }

        public async Task<string> GetSmallPayloadAsync()
        {
            return (await client.GetVersionAsync(new EmptyRequest())).ApiVersion;
        }

        public async Task<List<MeteoriteLanding>> StreamLargePayloadAsync()
        {
            List<MeteoriteLanding> meteoriteLandings = new List<MeteoriteLanding>();

            using var call = client.GetLargePayload(new EmptyRequest());
            while (await call.ResponseStream.MoveNext())
            {
                meteoriteLandings.Add(call.ResponseStream.Current);
            }

            return meteoriteLandings;
        }

        public async Task<IList<MeteoriteLanding>> GetLargePayloadAsListAsync()
        {
            return (await client.GetLargePayloadAsListAsync(new EmptyRequest())).MeteoriteLandings;
        }

        public async Task<string> PostLargePayloadAsync(MeteoriteLandingList meteoriteLandings)
        {
            return (await client.PostLargePayloadAsync(meteoriteLandings)).Status;
        }
    }
}
