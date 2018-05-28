using System.Net.Http;
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
    public class HomeController : AServiceController
    {
//        [Authorize]
        public async Task<ActionResult> Index()
        {
            if (LoggedInUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var apiRequest = CreateRequestToService(HttpMethod.Get, "api/users");

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            var content = apiResponse.Content.ReadAsStringAsync();
            var users = Library.Deserialize<UserViewModel>(content.Result);
//            var users = Library.AsObjectList<UserModel>(content.Result);

            return View(users);
        }

        //        public ActionResult Index()
        //        {
        //            return View();
        //        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}