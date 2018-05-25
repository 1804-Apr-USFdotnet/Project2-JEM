using FTV_Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Mvc;
using FTV_WEB.BL;

namespace FTV_Web.Controllers
{
    public class AccountController : AServiceController
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel account)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Login");
            apiRequest.Content = new ObjectContent<LoginViewModel>(account, new JsonMediaTypeFormatter());

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Account");
            }

            PassCookiesToClient(apiResponse);

            string content = await apiResponse.Content.ReadAsStringAsync();
            LoggedInUser = Library.AsObject<UserModel>(content);
            System.Web.HttpContext.Current.Session["Username"] = LoggedInUser?.UserName;

            return RedirectToAction("Index", "Home", content);
        }

        // GET: Account/Logout
        public async Task<ActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Account/Logout");

            HttpResponseMessage apiResponse;

            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            PassCookiesToClient(apiResponse);
            System.Web.HttpContext.Current.Session.Remove("Username");
            return RedirectToAction("Login", "Account");
        }

        private bool PassCookiesToClient(HttpResponseMessage apiResponse)
        {
            if (apiResponse.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            {
                foreach (string value in values)
                {
                    Response.Headers.Add("Set-Cookie", value);
                }
                return true;
            }
            return false;
        }
    }   
}

