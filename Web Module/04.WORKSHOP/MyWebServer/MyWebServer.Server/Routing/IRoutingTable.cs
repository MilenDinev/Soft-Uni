namespace MyWebServer.Server.Routi
{
    using MyWebServer.Server.Http;

    public interface IRoutingTable
    {
        void Map(string url, HttpResponse response);

        void Map(string url, HttpMethod method, HttpResponse response);

        void MapGet(string url, HttpResponse response);

    }
}
