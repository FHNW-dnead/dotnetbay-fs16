using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DotNetBay.WebApi
{
    public class StatusController : ApiController
    {
        [Route("api/status")]
        [HttpGet]
        public IHttpActionResult HowAreYou()
        {
            return this.Ok("I'm fine. Thanks.");
        }
    }
}
