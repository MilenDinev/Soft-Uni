namespace MyWebServer.Server
{
    using System;
    using System.Net;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using MyWebServer.Server.Http;
    using MyWebServer.Server.Routing;

    public  class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;
        private readonly RoutingTable routingtable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.listener = new TcpListener(this.ipAddress, this.port);
            this.routingtable = new RoutingTable();

            routingTableConfiguration(this.routingtable);
        }


        public HttpServer(int port, Action<IRoutingTable> routingTable) : this("127.0.0.1", port, routingTable)
        {

        }

        public HttpServer(Action<IRoutingTable> routingTable):this(8080, routingTable)
        {

        }

        public async Task Start ()
        {
            this.listener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine("Listening for requests...");


            while (true)
            {

                var connection = await this.listener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                var requestText = await this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                var response = this.routingtable.ExecuteRequest(request);

                await WriteResponse(networkStream, response);

                connection.Close();
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLenght = 1024;
            var buffer = new byte[bufferLenght];
            var totalBytes = 0;

            var requestBuilder = new StringBuilder();
            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLenght);

                totalBytes += bytesRead;
                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }


                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);


            return requestBuilder.ToString().TrimEnd();
        }


        private async Task WriteResponse(NetworkStream networkStream, HttpResponse response)
        {

            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            await networkStream.WriteAsync(responseBytes);
        }
    }
}
