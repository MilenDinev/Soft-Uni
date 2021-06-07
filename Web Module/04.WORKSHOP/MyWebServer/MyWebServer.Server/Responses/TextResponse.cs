namespace MyWebServer.Server.Responses
{
    using MyWebServer.Server.Common;
    using MyWebServer.Server.Http;
    using System.Text;

    public class TextResponse : HttpResponse
    {
        public TextResponse(string text) : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);
            var contentLength = Encoding.UTF8.GetByteCount(text).ToString();

            this.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            this.Headers.Add("Content-Length", $"{contentLength}");
        }
    }
}
