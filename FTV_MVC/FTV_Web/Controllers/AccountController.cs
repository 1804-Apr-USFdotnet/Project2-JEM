using FTV_Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using FTV.DAL.Models;
using FTV.DAL.ViewModels;
using FTV_WEB.BL;
using LoginViewModel = FTV.DAL.ViewModels.LoginViewModel;
using RegisterViewModel = FTV.DAL.ViewModels.RegisterViewModel;

namespace FTV_Web.Controllers
{
    public class AccountController : AServiceController
    {
        // GET: Account/Details/id
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Users/{id}");
//            apiRequest.Content = new ObjectContent<int>(id, new JsonMediaTypeFormatter());

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

            PassCookiesToClient(apiResponse);

            string content = await apiResponse.Content.ReadAsStringAsync();
            var user = Library.AsObject<UserModel>(content);

            return View(user);
        }


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
            System.Web.HttpContext.Current.Session["Id"] = LoggedInUser?.Id;

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

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel account)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Register");
            apiRequest.Content = new ObjectContent<RegisterViewModel>(account, new JsonMediaTypeFormatter());

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return RedirectToAction("Register", "Account");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Register", "Account");
            }

            //PassCookiesToClient(apiResponse);

            //string content = await apiResponse.Content.ReadAsStringAsync();
            //LoggedInUser = Library.AsObject<UserModel>(content);
            //System.Web.HttpContext.Current.Session["Username"] = LoggedInUser?.UserName;

            return RedirectToAction("Login", "Account");
        }

        // GET: Account/Edit
        public ActionResult Edit()
        {
            EditViewModel editView = new EditViewModel()
            {
                FirstName = LoggedInUser.FirstName,
                LastName = LoggedInUser.LastName,
                InGameName = LoggedInUser.InGameName
            };
            return View(editView);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(EditViewModel account)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, $"api/Users/{LoggedInUser.Id}");
            apiRequest.Content = new ObjectContent<EditViewModel>(account, new JsonMediaTypeFormatter());

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
            return RedirectToAction("Details", "Account", new {id = LoggedInUser.Id});
        }

    }   
}

