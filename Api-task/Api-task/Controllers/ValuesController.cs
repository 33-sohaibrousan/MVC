using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_task.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "sohaib", "malik" };
        }

        // GET api/values/5
        public string Get(int id)
        {if (id == 1)
                return "soahib";
            else if (id == 2)
                return "malik";
            else
            {
                return "try again man";
            }

        }

            // POST api/values
            public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
