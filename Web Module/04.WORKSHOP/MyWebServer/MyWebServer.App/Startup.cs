namespace MyWebServer.App
{
    using System.Threading.Tasks;
    using MyWebServer;
    using MyWebServer.App.Controllers;
    using MyWebServer.Controllers;

    //localhost 127.0.0.1

    public class Startup
    {
        static async Task Main(string[] args) 
            => await new HttpServer(routes => routes
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
            .MapGet<HomeController>("/Softuni", c => c.ToSoftUni())
            .MapGet<AnimalsController>("/Cats", c => c.Cats())
            .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
            .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
            .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies()))
            .Start();
        

    }
}
