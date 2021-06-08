using System.Web.Http;
using System.Web.Http.OData;

namespace BuildableWebApi.Controllers
{
    public class DataReadController : ApiController
    {
        [HttpGet]
        [EnableQuery(PageSize = 10)]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
