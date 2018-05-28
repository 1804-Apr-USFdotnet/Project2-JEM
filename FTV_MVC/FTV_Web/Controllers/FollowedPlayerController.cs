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
    public class FollowedPlayerController : AServiceController
    {

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


            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, $"api/User/{id}/FollowedPlayers");
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

        public async Task<ActionResult> Delete(int id)
        {
            if (LoggedInUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Delete, $"api/User/FollowedPlayers/{id}");

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

             return RedirectToAction("Index", "Home");
        }
    }
}