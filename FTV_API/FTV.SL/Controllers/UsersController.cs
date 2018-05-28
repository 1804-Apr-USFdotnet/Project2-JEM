using System;
using AutoMapper;
using FTV.DAL;
using FTV.DAL.Models;
using FTV.DAL.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Owin.Security.Provider;

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
        public IEnumerable<UserViewModel> Get()
        {
            return Mapper.Map<List<UserViewModel>>(_context.Users.GetAll());
        }

        // GET: api/Users/5
        [HttpGet]
        public UserViewModel Get(int id)
        {
            var user = _context.Users.Get(id);
            if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<UserViewModel>(user);
        }

        [HttpGet]
        public Boolean Get(string userName)
        {
            var userNameFind = _context.Users.GetAll().FirstOrDefault(c => c.UserName == userName);
            return (userNameFind == null ? true: false);

        }

        // POST: api/Users
        [HttpPost]
        public UserViewModel Post([FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var user = Mapper.Map<UserViewModel, User>(userViewModel);
            var userName = user.UserName;
            UsersController checkName = new UsersController();
            var check = checkName.Get(userName);
            if (check == false)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            else
            {
                _context.Users.Add(user);
                _context.Complete();
                return userViewModel;
            }
        }

        // PUT: api/Users/5
        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] UserEditViewModel userViewModel)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var userInDb = _context.Users.GetAll().SingleOrDefault(c => c.Id == id);
            if (userInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(userViewModel, userInDb);
            _context.Complete();
            return StatusCode(HttpStatusCode.NoContent);
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

        [HttpGet]
        [ResponseType(typeof(Comment))]
        [Route("~/api/User/{id}/Comments")]
        public IHttpActionResult GetCommentByUser(int id)
        {
            var user = _context.Users.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<List<CommentViewModel>>(user.Comments));
        }

        [HttpPost]
        [Route("~/api/User/{id}/FollowedPlayers")]
        public IHttpActionResult AddFollowedPlayer(int id, FollowedPlayer fp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mapper.Map<FollowedPlayerViewModel>(fp);

            _context.FollowedPlayers.Add(fp);
            _context.Complete();
            return Ok();
        }

        [HttpGet]
        [ResponseType(typeof(FollowedPlayer))]
        [Route("~/api/User/{id}/FollowedPlayers")]
        public IHttpActionResult GetFollowedPlayersByUser(int id)
        {
            var user = _context.Users.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<List<FollowedPlayerViewModel>>(user.FollowedPlayers));
        }

        [ResponseType(typeof(FollowedPlayer))]
        [Route("~/api/User/FollowedPlayers/{id}")]
        public IHttpActionResult DeleteComment(int id)
        {
            FollowedPlayer fp = _context.FollowedPlayers.Get(id);
            if (fp == null)
            {
                return NotFound();
            }

            _context.FollowedPlayers.Remove(fp);
            _context.Complete();

            return Ok(fp);
        }
    }


}