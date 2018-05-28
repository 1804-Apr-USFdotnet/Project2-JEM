using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using FTV.DAL.Models;
using FTV.DAL.ViewModels;
using FTV_Web.Models;
using FTV_WEB.BL;
using Microsoft.Ajax.Utilities;

namespace FTV_Web.Controllers
{
    public class CommentController : AServiceController
    {
        [HttpPut]
        public async Task<ActionResult> Edit(int id, EditCommentViewModel comment)
        {
            if (LoggedInUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, $"api/Comments/{id}");
            apiRequest.Content = new ObjectContent<EditCommentViewModel>(comment, new JsonMediaTypeFormatter());

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return RedirectToAction("Edit", "Account");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Edit", "Account");
            }
            string content = await apiResponse.Content.ReadAsStringAsync();
            var commentUserId = Library.AsObject<CommentViewModel>(content).UserId;
            return RedirectToAction("Details", "Account", new { id = commentUserId });
        }

        public ActionResult Create(int id)
        {
            ViewBag.UserId = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(int id, CreateCommentViewModel comment)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            comment.UserId = id;


            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Comments");
            apiRequest.Content = new ObjectContent<CreateCommentViewModel>(comment, new JsonMediaTypeFormatter());

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return RedirectToAction("Create", "Comment");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Create", "Comment");
            }

            return RedirectToAction("Details", "Account", new {id = id});
        }

        //        // GET: Comment/Edit5
        //        [HttpGet]
        //        public async Task<ActionResult> Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //
        //            if (LoggedInUser == null)
        //            {
        //                return RedirectToAction("Login", "Account");
        //            }
        //
        //            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Comments/{id}");
        //
        //            HttpResponseMessage apiResponse;
        //            try
        //            {
        //                apiResponse = await HttpClient.SendAsync(apiRequest);
        //            }
        //            catch
        //            {
        //                return RedirectToAction("Edit", "Account");
        //            }
        //
        //            if (!apiResponse.IsSuccessStatusCode)
        //            {
        //                return RedirectToAction("Edit", "Account");
        //            }
        //            string content = await apiResponse.Content.ReadAsStringAsync();
        //            var comment = Library.AsObject<CommentViewModel>(content);
        //            ViewBag.CommentId = comment.Id;
        //            ViewBag.UserId = comment.UserId;
        //
        //            return View(Library.AsObject<EditCommentViewModel>(content));
        //        }
    }
}