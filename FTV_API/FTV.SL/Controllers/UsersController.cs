using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FTV.DAL;
using FTV.DAL.Dtos;
using FTV.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Repositories;

namespace FTV.SL.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UnitOfWork _context;

        public UsersController()
        {
            _context = new UnitOfWork(new FTVContext());
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.GetAll();
        }

        // GET: api/Users/5
        [HttpGet]
        public User Get(int id)
        {
            var user = _context.Users.Get(id);
            if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public User Post([FromBody] User user)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Users.Add(user);
            _context.Complete();
            return user;
        }

        // PUT: api/Users/5
        [HttpPut]
        public void Put(int id, [FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var userInDb = _context.Users.GetAll().SingleOrDefault(c => c.Id == id);
            if (userInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(userViewModel, userInDb);
            _context.Complete();
        }

        // DELETE: api/Users/5
        [HttpDelete]
        public void Delete(int id)
        {
            var user = _context.Users.GetAll().SingleOrDefault(c => c.Id == id);
            if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Users.Remove(user);
            _context.Complete();
        }

//         Authentication

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("~/api/User/Register")]
        [System.Web.Mvc.AllowAnonymous]
        public IHttpActionResult Register(User user)
        {
            if (!ModelState.IsValid) return BadRequest();

            //actually register 
            var userStore = new UserStore<IdentityUser>(new FTVContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var userAdd = new IdentityUser(user.UserName);

            if (userManager != null)
            {
                if (userManager.Users.Any(u => u.UserName == userAdd.UserName)) return BadRequest();

                userManager.Create(userAdd, user.Password);
            }

            return Ok();
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("~/api/User/Login")]
        [System.Web.Mvc.AllowAnonymous]
        public IHttpActionResult LogIn(User user)
        {
            if (!ModelState.IsValid) return BadRequest();

            //actually Login 
            var userStore = new UserStore<IdentityUser>(new FTVContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var userLogin = userManager.Users.FirstOrDefault(u => u.UserName == user.UserName);

            if (user == null) return BadRequest();

            if (!userManager.CheckPassword(userLogin, user.Password)) return Unauthorized();

            var authManager = Request.GetOwinContext().Authentication;
            var claimsIdentity = userManager.CreateIdentity(userLogin, "ApplicationCookie");

            authManager.SignIn(new AuthenticationProperties {IsPersistent = true}, claimsIdentity);

            return Ok();
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("~/api/User/Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Ok();
        }
    }
}