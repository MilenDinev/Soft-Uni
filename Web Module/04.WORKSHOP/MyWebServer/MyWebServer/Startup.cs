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
            .MapGet("/Cats", request =>
                {
                    const string nameKey = "Name";
                    var query = request.Query;

                    var catName = query.ContainsKey(nameKey)
                    ? query[nameKey]
                    : "the cats";

                    var result = $"<h1>Hello from {catName}!</h1>";

                   return  new HtmlResponse(result);
                })
            .MapGet("/Dogs", new HtmlResponse("<h1>Hello from the dogs!</h1>")))
            .Start();


    }
}
