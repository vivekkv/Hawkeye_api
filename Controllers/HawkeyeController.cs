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

    [Route("api/hawkeye")]
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
            try
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

            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return NoContent();
            }
        }

        [HttpPost]
        [Route("cpu")]
        public IActionResult Cpu([FromBody]RequestIdentity identity)
        {
            try
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
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return NoContent();
            }
        }


        [HttpPost]
        [Route("process")]
        public IActionResult Process([FromBody]RequestIdentity identity)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NoContent();
            }
        }

        [HttpPost]
        [Route("recentApplications")]
        public IActionResult RecentApplications([FromBody]RequestIdentity identity)
        {
            try
            {
                var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.hawkeye));
                var query = string.Format("SELECT \"Name\" from " +
                                "hawkeye.hawkeye_application WHERE \"workspace_uuid\"='{0}' AND \"event_timestamp\" >= {1} AND \"event_timestamp\" <= {2}",
                                identity.WorkspaceId, identity.StartDate, identity.EndDate);

                if (!string.IsNullOrEmpty(identity.SensorId))
                {
                    query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
                }

                query += " LIMIT 10 ALLOW FILTERING";
                var data = mapper.Fetch<RecentApplication>(query);

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
        [Route("ipInfo")]
        public IActionResult IpReputations([FromBody]RequestIdentity identity)
        {
            try
            {
                var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.hawkeye));
                var query = string.Format("SELECT \"Name\",\"Ipv4\", \"Ipv6\", \"MACAddress\" from " +
                                "hawkeye.hawkeye_ip_info WHERE \"workspace_uuid\"='{0}' AND \"event_timestamp\" >= {1} AND \"event_timestamp\" <= {2}",
                                identity.WorkspaceId, identity.StartDate, identity.EndDate);

                if (!string.IsNullOrEmpty(identity.SensorId))
                {
                    query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
                }

                query += " LIMIT 10 ALLOW FILTERING";
                var data = mapper.Fetch<IpReputation>(query);

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
        [Route("resource")]
        public IActionResult getResource([FromBody]RequestIdentity identity)
        {
            try
            {
                var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.hawkeye));
                var query = string.Format("SELECT \"CpuUsage\",\"DiscWrite\", \"DiskRead\", \"DiskTransfer\", \"FreeMemory\" from " +
                                "hawkeye.hawkeye_resource WHERE \"workspace_uuid\"='{0}' AND \"event_timestamp\" >= {1} AND \"event_timestamp\" <= {2}",
                                identity.WorkspaceId, identity.StartDate, identity.EndDate);

                if (!string.IsNullOrEmpty(identity.SensorId))
                {
                    query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
                }

                query += " LIMIT 10 ALLOW FILTERING";
                var data = mapper.Fetch<Resource>(query);

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
