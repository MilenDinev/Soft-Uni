namespace MyWebServer.App.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Responses;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Index() 
            =>  Text("Hello from Milen");

    }
}
