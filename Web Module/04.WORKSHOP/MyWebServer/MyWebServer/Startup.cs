namespace MyWebServer
{
    using System.Threading.Tasks;
    using MyWebServer.Server;
    using MyWebServer.Server.Responses;

    //localhost 127.0.0.1

    public class Startup
    {
        static async Task Main(string[] args) 
            => await new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from Milen"))
            .MapGet("/Cats", new TextResponse("<h1>Hello from the cats!</h1>", "text/html"))
            .MapGet("/Dogs", new TextResponse("<h1>Hello from the dogs!</h1>", "text/html")))
            .Start();


    }
}
