using FTV.DAL;
using FTV.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Linq;
using System.Net.Http;
using System.Web.Http;


namespace FTV.SL.Controllers
{
    public class UsersController : ApiController
    {

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("~/api/User/Register")]
        [System.Web.Mvc.AllowAnonymous]
        public IHttpActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //actually register 
            var userStore = new UserStore<IdentityUser>(new FTVContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var userAdd = new IdentityUser(user.UserName);

            if (userManager != null)
            {
                if (userManager.Users.Any(u => u.UserName == userAdd.UserName))
                {
                    return BadRequest();
                }

                userManager.Create(userAdd, user.Password);
            }

            return Ok();

        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("~/api/User/Login")]
        [System.Web.Mvc.AllowAnonymous]
        public IHttpActionResult LogIn(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //actually Login 
            var userStore = new UserStore<IdentityUser>(new FTVContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var userLogin = userManager.Users.FirstOrDefault(u => u.UserName == user.UserName);

            if (user == null)
            {
                return BadRequest();
            }

            if (!userManager.CheckPassword(userLogin, user.Password))
            {
                return Unauthorized();
            }

            var authManager = Request.GetOwinContext().Authentication;
            var claimsIdentity = userManager.CreateIdentity(userLogin, "ApplicationCookie");

            authManager.SignIn(new AuthenticationProperties { IsPersistent = true, }, claimsIdentity);

            return Ok();

        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("~/api/User/Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Ok();
        }

        //// GET: api/Users
        //public IEnumerable<User> Get()
        //{
        //    return null;
        //}

        //// GET: api/Users/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Users
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Users/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Users/5
        //public void Delete(int id)
        //{
        //}
    }
}
