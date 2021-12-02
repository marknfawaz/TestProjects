using System.Threading.Tasks;
using System.Web;


namespace TestMvcApplication
{
    public class AppShutDownHandler : IHttpHandler
    {

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.  
            // Usually this would be false in case you have some state information preserved per request.  
            get { return true; }
        }


        public void ProcessRequest(HttpContext context)
        {
            string response = GenerateResponse(context);
            context.Response.Write($"<h1 style='Color:blue; font-size:15px;'>Our website is under maintainace. {response}</h1>");
        }

        public void TestMethod()
        {
            return;
        }
        private string GenerateResponse(HttpContext context)
        {
            return "This is a test handler";
        }
    }
}