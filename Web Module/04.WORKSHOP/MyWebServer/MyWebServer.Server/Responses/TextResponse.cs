namespace MyWebServer.Server.Responses
{ 
    using MyWebServer.Server.Http;

    public class TextResponse : ContentResponse
    {

        public TextResponse(string text) : base(text, "text/plain; charset=UTF-8")
        {

        }
    }
}
