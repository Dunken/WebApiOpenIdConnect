using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OIDC_WebApi.Controller
{
    [Authorize]
    public class AuthorizedController : ApiController
    {
        public string Get()
        {
            return "OK";
        }
    }
}
