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

    [Route("api/beacon")]
    public class BeaconController : Controller
    {
        private readonly ICassandraCore _cassandraCore;

        public BeaconController(ICassandraCore cassandraCore)
        {
            _cassandraCore = cassandraCore;
        }

        [HttpPost]
        [Route("websites")]
        public IActionResult RecentWebsites([FromBody]RequestIdentity identity)
        {
            try
            {

                var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.pathfinder));
                var query = string.Format("SELECT \"cat\", \"domain\", \"dest_ip\", \"private_ip\" from " +
                                "beacon.beacon_website WHERE \"workspace_uuid\"='{0}' AND  \"epoch_timestamp\" >= {1} AND \"epoch_timestamp\" <= {2}",
                                identity.WorkspaceId, identity.StartDate, identity.EndDate);

                if (!string.IsNullOrEmpty(identity.SensorId))
                {
                    query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
                }

                query += " LIMIT 10 ALLOW FILTERING";
                var data = mapper.Fetch<Websites>(query);

                if (data != null)
                {
                    return Ok(data);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NoContent();
            }
        }

        [HttpPost]
        [Route("ssh")]
        public IActionResult SshEvents([FromBody]RequestIdentity identity)
        {
            try
            {
                var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.pathfinder));
                var query = string.Format("SELECT \"destination_ip\", \"source_ip\", \"private_ip\", \"public_ip\", \"destination_port\" from " +
                                "beacon.beacon_ssh_workspace WHERE \"workspace_uuid\"='{0}' AND  \"event_timestamp\" >= {1} AND \"event_timestamp\" <= {2}",
                                identity.WorkspaceId, identity.StartDate, identity.EndDate);

                if (!string.IsNullOrEmpty(identity.SensorId))
                {
                    query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
                }

                query += " LIMIT 10 ALLOW FILTERING";
                var data = mapper.Fetch<SshActivity>(query);

                if (data != null)
                {
                    return Ok(data);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NoContent();
            }
        }
    }
}
