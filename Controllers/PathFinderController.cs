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

    [Route("api/pathfinder")]
    public class PathFinderController : Controller
    {
        private readonly ICassandraCore _cassandraCore;

        public PathFinderController(ICassandraCore cassandraCore)
        {
            _cassandraCore = cassandraCore;
        }

        [HttpPost]
        [Route("recentfiles")]
        public IActionResult RecentFiles([FromBody]RequestIdentity identity)
        {
            try
            {
                var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.pathfinder));
                var query = string.Format("SELECT \"Username\", \"FileName\", \"Action\" from " +
                                "pathfinder.pathfinder_activity_workspace WHERE \"workspace_uuid\"='{0}' AND  \"event_timestamp\" >= {1} AND \"event_timestamp\" <= {2}",
                                identity.WorkspaceId, identity.StartDate, identity.EndDate);

                if (!string.IsNullOrEmpty(identity.SensorId))
                {
                    query += string.Format(" AND \"sensor_uuid\"='{0}'", identity.SensorId);
                }

                query += " LIMIT 10 ALLOW FILTERING";
                var data = mapper.Fetch<FileActivity>(query);

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
