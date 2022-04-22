using System.Web.Http;
using System.Web.Http.OData;

namespace BuildableWebApi.Controllers
{
    using System.Web.Http;
    using System.Web.Http.OData;

    public class DataReadController : ApiController
    {
        [HttpGet]
        [EnableQuery(PageSize = 10)]
        [Route("")]
        public IHttpActionResult Get()
        {
            return (IHttpActionResult)Ok();
        }
    }
}
