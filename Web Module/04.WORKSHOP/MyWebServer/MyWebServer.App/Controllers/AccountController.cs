﻿namespace MyWebServer.App.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class AccountController : Controller
    {
        public AccountController(HttpRequest request)
            : base(request)
        {
        }



        public HttpResponse ActionWithCookie()
        {
            const string cookieName = "My-Cookie";

            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];
                return Text($"Cookies already exist - {cookie}");
            }

            this.Response.AddCookies(cookieName, "My-Value");
            this.Response.AddCookies("My-Second-Cookie", "My-Second-Value");
            return Text("Cookies Set!");
        }
    }
}
