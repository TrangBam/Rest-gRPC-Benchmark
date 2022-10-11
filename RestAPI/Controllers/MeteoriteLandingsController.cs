using Microsoft.AspNetCore.Mvc;
using RestAPI.Data;
using RestAPI.Model;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeteoriteLandingsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "API Version 1.0";
        }

        // GET api/values/LargePayload
        [HttpGet]
        [Route("LargePayload")]
        public ActionResult<IEnumerable<MeteoriteLanding>> GetLargePayloadAsync()
        {
            return MeteoriteLandingData.RestMeteoriteLandings;
        }

        // POST api/values/LargePayload
        [HttpPost]
        [Route("LargePayload")]
        public string PostLargePayload([FromBody] IEnumerable<MeteoriteLanding> meteoriteLandings)
        {
            return "SUCCESS";
        }
    }
}