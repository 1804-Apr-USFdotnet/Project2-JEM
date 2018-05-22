using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace FTV.SL.Controllers
{
    public class DataController : ApiController
    {
        public IHttpActionResult Get()
        {
            var user = Request.GetOwinContext().Authentication.User;

            string username = user.Identity.Name;

            List<string> roles =
                user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.ValueType.ToString()).ToList();

            return Ok($"Authenticated {username}, with roles: [{string.Join(",", roles)}]!");
        }
    }
}
