using FTV.DAL;
using FTV.DAL.Models;
using Repositories;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using FTV.DAL.ViewModels;
using FTV.SL.App_Start;

namespace FTV.SL.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly UnitOfWork _context;

        public CommentsController()
        {
            _context = new UnitOfWork(new FTVContext()); ;
        }

        // GET: api/Comments
        public IEnumerable<CommentViewModel> GetComments()
        {
            return Mapper.Map<List<CommentViewModel>>(_context.Comments.GetAll());
        }

        // GET: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            var comment = Mapper.Map<CommentViewModel>(_context.Comments.Get(id));
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }


        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment([FromUri] int id,[FromBody] EditCommentViewModel comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentInDb = _context.Comments.GetAll().SingleOrDefault(c => c.Id == id);
            if (commentInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(comment, commentInDb);
            _context.Complete();


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Comments
        [ResponseType(typeof(Comment))]
        public IHttpActionResult PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mapper.Map<CommentViewModel>(comment);

            _context.Comments.Add(comment);
            _context.Complete();

            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = _context.Comments.Get(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            _context.Complete();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
//            return _context.Comments.Count(e => e.Id == id) > 0;
            return _context.Comments.Get(id) != null;
        }
    }
}