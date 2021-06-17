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
            .MapStaticFiles()
            .MapControllers()
            .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
            .MapPost<CatsController>("/Cats/Save", c => c.Save()))
            .Start();
        

    }
}
