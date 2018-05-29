using FTV.DAL.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace FTV_Web.Controllers
{
    public class AServiceController : Controller
    {
        public static UserModel LoggedInUser;
        protected static readonly HttpClient HttpClient = new HttpClient(new HttpClientHandler() { UseCookies = false });
        private static readonly Uri serviceUri = new Uri("http://ec2-52-15-80-15.us-east-2.compute.amazonaws.com/FTV/");
//        private static readonly Uri serviceUri = new Uri("http://localhost:51542/");
        private static readonly string cookieName = "AuthTestCookie";

        protected HttpRequestMessage CreateRequestToService(HttpMethod method, string uri)
        {
            var apiRequest = new HttpRequestMessage(method, new Uri(serviceUri, uri));

            string cookieValue = Request.Cookies[cookieName]?.Value ?? ""; // ?. operator new in C# 7

            apiRequest.Headers.Add("Cookie", new CookieHeaderValue(cookieName, cookieValue).ToString());
            return apiRequest;
        }
    }
}