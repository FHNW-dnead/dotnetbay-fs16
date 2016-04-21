using System.Web.Http;

namespace DotNetBay.WebApi.Controllers
{
    public class StatusController : ApiController
    {
        [HttpGet]
        [Route("api/status")]
        public IHttpActionResult AreYouFine()
        {
            return this.Ok("I'm fine");
        }
    }
}
