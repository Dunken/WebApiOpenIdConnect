using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OIDC_WebApi.Controller
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Get()
        {
            // now redirect
            var response = Request.CreateResponse(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri("http://localhost:41040/ApiAccess.html");
            return response;
        }
    }
}
