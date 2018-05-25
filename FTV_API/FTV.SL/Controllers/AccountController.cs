using AutoMapper;
using FTV.DAL;
using FTV.DAL.Models;
using FTV.DAL.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Repositories;

namespace FTV.SL.Controllers
{
    public class AccountController : ApiController
    {
        //         Authentication
        private readonly UnitOfWork _context;
        public AccountController()
        {
            _context = new UnitOfWork(new FTVContext());
        }
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

            
            var userNameFind = _context.Users.GetAll().FirstOrDefault(c => c.UserName == account.UserName);
            var user = Mapper.Map<User, UserViewModel>(userNameFind);
            return Ok(Mapper.Map<UserViewModel, ShowUserViewModel>(user));
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
