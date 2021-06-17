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
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
            .MapGet<HomeController>("/Softuni", c => c.ToSoftUni())
            .MapGet<HomeController>("/Error", c => c.Error())
            .MapGet<HomeController>("/StaticFiles", c => c.StaticFiles())
            .MapGet<AccountController>("/Cookies", c => c.CookiesCheck())
            .MapGet<AccountController>("/Session", c => c.SessionCheck())
            .MapGet<AccountController>("/Login", c => c.Login())
            .MapGet<AccountController>("/Logout", c => c.Logout())
            .MapGet<AccountController>("/Authentication", c => c.AuthenticationCheck())
            .MapGet<AnimalsController>("/Cats", c => c.Cats())
            .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
            .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
            .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
            .MapGet<CatsController>("/Cats/Create", c => c.Create())
            .MapPost<CatsController>("/Cats/Save", c => c.Save()))
            .Start();
        

    }
}
