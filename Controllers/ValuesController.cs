using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hawkeye_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hawkeye_api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public dynamic Get()
        {
            var beaconStore = new CassandraCore("10.0.3.26,10.0.4.77,10.0.3.218");
            var result = beaconStore.GetData("SELECT * FROM beacon.beacon_alert LIMIT 10;",KeySpaces.beacon);

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
