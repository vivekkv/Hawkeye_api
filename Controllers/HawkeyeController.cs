namespace hawkeye_api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using hawkeye_api.Models;
    using Microsoft.AspNetCore.Mvc;
    using hawkeye_api.Models.Common;
    using Cassandra;
    using Cassandra.Mapping;
    using hawkeye_api.Models.DbModels;

    [Route("api/[controller]")]
    public class HawkeyeController : Controller
    {
        private readonly ICassandraCore _cassandraCore;

        public HawkeyeController(ICassandraCore cassandraCore)
        {
            _cassandraCore = cassandraCore;
        }

        [HttpPost]
        [Route("bandwidth")]
        public IActionResult Bandwidth([FromBody]RequestIdentity identity)
        {
            var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.hawkeye));
            var query = string.Format("SELECT \"event_timestamp\", \"BytesReceived\", \"BytesSent\", \"Speed\", \"TimeStamp\"  from " +
                            "hawkeye.hawkeye_network WHERE \"workspace_uuid\"='{0}' AND \"event_timestamp\" >= {1} AND \"event_timestamp\" <= {2}", 
                            identity.WorkspaceId, identity.StartDate, identity.EndDate);

            if (!string.IsNullOrEmpty(identity.SensorId))
            {
                query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
            }

            query += " LIMIT 10 ALLOW FILTERING";
            var data = mapper.Fetch<BandWidth>(query);

            if (data != null)
            {
                return Ok(data);
            }

            return NoContent();
        }

         [HttpPost]
        [Route("cpu")]
        public IActionResult Cpu([FromBody]RequestIdentity identity)
        {
            var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.hawkeye));
            var query = string.Format("SELECT \"Name\", \"MaxClockSpeed\", \"ThreadCount\", \"NumberOfCores\", \"AddressWidth\"  from " +
                            "hawkeye.hawkeye_processor WHERE \"workspace_uuid\"='{0}' AND \"event_timestamp\" >= {1} AND \"event_timestamp\" <= {2}", 
                            identity.WorkspaceId, identity.StartDate, identity.EndDate);

            if (!string.IsNullOrEmpty(identity.SensorId))
            {
                query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
            }

            query += " LIMIT 10 ALLOW FILTERING";
            var data = mapper.Fetch<Processor>(query);

            if (data != null)
            {
                return Ok(data);
            }

            return NoContent();
        }

        
         [HttpPost]
        [Route("process")]
        public IActionResult Process([FromBody]RequestIdentity identity)
        {
            var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.hawkeye));
            var query = string.Format("SELECT \"Name\", \"Computer\" from " +
                            "hawkeye.hawkeye_process WHERE \"workspace_uuid\"='{0}' AND \"event_timestamp\" >= {1} AND \"event_timestamp\" <= {2}", 
                            identity.WorkspaceId, identity.StartDate, identity.EndDate);

            if (!string.IsNullOrEmpty(identity.SensorId))
            {
                query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
            }

            query += " LIMIT 10 ALLOW FILTERING";
            var data = mapper.Fetch<Process>(query);

            if (data != null)
            {
                return Ok(data);
            }

            return NoContent();
        }
    }
}
