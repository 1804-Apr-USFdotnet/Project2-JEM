using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FTV_Web.Controllers
{
    public class HomeController : AServiceController
    {
        public async Task<ActionResult> Index()
        {
//            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Data");
//
//            HttpResponseMessage apiResponse;
//            try
//            {
//                apiResponse = await HttpClient.SendAsync(apiRequest);
//            }
//            catch
//            {
//                return View("Error");
//            }

            if (!User.Identity.IsAuthenticated)
            {
//                if (apiResponse.StatusCode != HttpStatusCode.Unauthorized)
//                {
//                    return View("Error");
//                }
                ViewBag.Message = "Not logged in!";
            }
            else
            {
//                var contentString = await apiResponse.Content.ReadAsStringAsync();
                ViewBag.Message = "Logged in! Result: " + User.Identity.GetUserName();
            }

            return View();
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