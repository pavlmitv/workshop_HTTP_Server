﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            listener = new TcpListener(this.ipAddress, port);

        }

        public async Task Start()
        {
            this.listener.Start();

            Console.WriteLine($"Server started on port {this.port}...");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                //разбиваме stream-a на части. Така ако има много голям request, който може да задръсти паметта, няма да бъде приет. Може да сложим условие за ограничение

                var request = await this.ReadRequest(networkStream);
                Console.WriteLine(request);
                //задаваме response и header-и в него (content length, type, тн.; (търси Response Message Example в нета)); трябва да се заяви дължина на съдържанието и да се заяви, че е текст UTF-8 формат 

                await WriteResponse(networkStream);

                connection.Close();
            }

        }
        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            while (networkStream.DataAvailable)
            {
                int bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            return requestBuilder.ToString();
        }
        private async Task WriteResponse(NetworkStream networkStream)
        {
            var content = @"<h1>Поздрави!</h1>";
            var contentlength = Encoding.UTF8.GetByteCount(content);

            var response = $@"
HTTP/1.1 200 OK
Server: My web server
Date: {DateTime.UtcNow:r}
Content-Length: {contentlength}
Content-Type: text/html; charset=UTF-8

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}