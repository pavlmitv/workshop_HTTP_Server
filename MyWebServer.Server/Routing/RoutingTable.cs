using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;
using System;
using System.Collections.Generic;


namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;   //GET(HttpMethod) - "/Cats"(string) - {response..}(HttpResponse)

        public RoutingTable()
        {
            this.routes = new Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>>()
            {
                //инициализираме речника в конструктора
                [HttpMethod.Get] = new Dictionary<string, Func<HttpRequest, HttpResponse>>(),
                [HttpMethod.Post] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Delete] = new(),
            };


        }
        public IRoutingTable Map(HttpMethod method, string path, HttpResponse response)
        {
            Guard.AgainstNull(response, nameof(response));


            return this.Map(method, path, request => response);    //начина, за да върнем RoutingTable; така се връща мапването на url-a към response-a
        }

        public IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path.ToLower()] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response)
            => MapGet(path, request => response);

        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
             => Map(HttpMethod.Get, path, responseFunction);

        public IRoutingTable MapPost(string path, HttpResponse response)
             => MapPost(path, request => response);

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => Map(HttpMethod.Post, path, responseFunction);

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestPath];

            return responseFunction(request);
        }
    }
}
