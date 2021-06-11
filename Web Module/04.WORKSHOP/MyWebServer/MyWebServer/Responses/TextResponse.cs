namespace MyWebServer.Responses
{ 
    using MyWebServer.Http;

    public class TextResponse : ContentResponse
    {

        public TextResponse(string text) : base(text, "text/plain; charset=UTF-8")
        {

        }
    }
}
