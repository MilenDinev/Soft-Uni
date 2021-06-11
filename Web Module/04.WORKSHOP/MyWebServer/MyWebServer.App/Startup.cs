namespace MyWebServer.App
{
    using System.Threading.Tasks;
    using MyWebServer;
    using MyWebServer.App.Controllers;


    //localhost 127.0.0.1

    public class Startup
    {
        static async Task Main(string[] args) 
            => await new HttpServer(routes => routes
            .MapGet("/", request => new HomeController(request).Index())
            .MapGet("/Cats", request => new AnimalsController(request).Cats())
            .MapGet("/Dogs", request => new AnimalsController(request).Dogs()))
            .Start();


    }
}
