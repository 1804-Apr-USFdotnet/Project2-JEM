﻿using System.Data.Entity.Infrastructure;
using FTV.DAL.ViewModels;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        public async Task<ActionResult> Create(int id, CreateFollowedPlayerViewModel fp)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            TwoFollowedPlayerViewModel followedPlayer = new TwoFollowedPlayerViewModel()
            {
                InGameName = fp.InGameName,
                UserId = id
            };


            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, $"api/User/{id}/FollowedPlayers");
            apiRequest.Content = new ObjectContent<TwoFollowedPlayerViewModel>(followedPlayer, new JsonMediaTypeFormatter());

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return RedirectToAction("Create", "FollowedPlayer");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Create", "FollowedPlayer");
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