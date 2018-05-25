using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FTV.DAL;
using FTV.DAL.Models;
using FTV.DAL.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace FTV.SL.Controllers
{
    public class AccountController : ApiController
    {
        //         Authentication

        [HttpPost]
        [Route("~/api/Account/Register")]
        [AllowAnonymous]
        public IHttpActionResult Register(User user)
        {
            if (!ModelState.IsValid) return BadRequest();

            //actually register 
            var userStore = new UserStore<IdentityUser>(new DataDbContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var userRegister = new IdentityUser(user.UserName);

            if (userManager.Users.Any(u => u.UserName == user.UserName)) return BadRequest();
            userManager.Create(userRegister, user.Password);
            var addNormDb = new UsersController();
            var userAdd = Mapper.Map<User, UserViewModel>(user);
            addNormDb.Post(userAdd);
       

            return Ok();
        }

        [HttpPost]
        [Route("~/api/Account/Login")]
        [AllowAnonymous]
        public IHttpActionResult LogIn(Account account)
        {
            if (!ModelState.IsValid) return BadRequest();

            //actually Login 
            var userStore = new UserStore<IdentityUser>(new DataDbContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var userLogin = userManager.Users.FirstOrDefault(u => u.UserName == account.UserName);

            if (account == null) return BadRequest();

            if (!userManager.CheckPassword(userLogin, account.Password)) return Unauthorized();
            var authManager = Request.GetOwinContext().Authentication;
            var claimsIdentity = userManager.CreateIdentity(userLogin, WebApiConfig.AuthenticationType);

            authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claimsIdentity);

            var userCont = new UsersController();
            var accountInfo = userCont.Get(account);
            return Ok(accountInfo);
        }

        [HttpGet]
        [Route("~/api/Account/Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(WebApiConfig.AuthenticationType);
            return Ok();
        }
    }
}
