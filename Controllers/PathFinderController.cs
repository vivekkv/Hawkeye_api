using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hawkeye_api.Models;
using Microsoft.AspNetCore.Mvc;
using hawkeye_api.Models.Common;

namespace hawkeye_api.Controllers
{
    using System;

    [Route("api/[controller]")]
    public class PathFinderController : Controller
    {
        private readonly ICassandraCore _cassandraCore;

        public PathFinderController(ICassandraCore cassandraCore)
        {
            _cassandraCore = cassandraCore;
        }

        [HttpPost]
        public dynamic RecentFiles([FromBody]RequestIdentity identity)
        {
            return _cassandraCore.GetData("SELECT * FROM pathfinder.path_finder_activity WHERE LogTime >="+ identity.StartDate +" AND LogTime <= "+ identity.EndDate +
                                            "AND workspace_uuid='"+ identity.WorkspaceId +"' LIMIT 1000 ALLOW FILTERING;", KeySpaces.beacon);
        }

    }
}
