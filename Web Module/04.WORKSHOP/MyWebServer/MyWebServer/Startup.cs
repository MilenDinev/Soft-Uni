namespace MyWebServer
{
    using System.Threading.Tasks;
    using MyWebServer.Server;
    using MyWebServer.Server.Responses;

    //localhost 127.0.0.1

    public class Startup
    {
        static async Task Main(string[] args)
        {
            var server = new HttpServer("127.0.0.1", 8080, routes => routes.Map("/", new TextResponse("Hello from Milen")));

            await server.Start();
        }
    }
}
