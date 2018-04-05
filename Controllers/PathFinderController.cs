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
    public class PathFinderController : Controller
    {
        private readonly ICassandraCore _cassandraCore;

        public PathFinderController(ICassandraCore cassandraCore)
        {
            _cassandraCore = cassandraCore;
        }

        [HttpPost]
        public IActionResult RecentFiles([FromBody]RequestIdentity identity)
        {
            var mapper = new Mapper(_cassandraCore.GeSession(KeySpaces.pathfinder));
            
            IEnumerable<FileActivity> data = null;

            if(identity.SensorId == null) {

                data = mapper.Fetch<FileActivity>("SELECT \"LogTime\", \"Username\", \"FileName\", \"FilePath\", \"Action\" from "+
                            "pathfinder.path_finder_activity WHERE workspace_uuid={0} LIMIT 10 ALLOW FILTERING", identity.WorkspaceId);
            } else {
                
                
            }

            if(data != null) {

                return Ok(data);
            }

            return NoContent();
        }
    }
}
