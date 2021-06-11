namespace MyWebServer.App.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Index() =>  Text("Hello from Milen");

        public HttpResponse LocalRedirect() => Redirect("/Cats");
        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");

    }
}
