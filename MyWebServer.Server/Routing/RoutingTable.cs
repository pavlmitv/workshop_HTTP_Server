using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;   //GET(HttpMethod) - "/Cats"(string) - {response..}(HttpResponse)

        public RoutingTable()
        {
            this.routes = new Dictionary<HttpMethod, Dictionary<string, HttpResponse>>()    
            {
                //инициализираме речника в конструктора
                [HttpMethod.Get] = new Dictionary<string, HttpResponse>(),
                [HttpMethod.Post] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Delete] = new(),
            };

             
        }
        public IRoutingTable Map(string url, HttpMethod method, HttpResponse response)
        {
            switch (method)
            {
                case HttpMethod.Get:
                  return  this.MapGet(url, response);
                    break;
                case HttpMethod.Post:
                    break;
                case HttpMethod.Put:
                    break;
                case HttpMethod.Delete:
                    break;
                default:
                    break;
            }
            throw new InvalidOperationException($"Method {method} is not supported");
        }

        public IRoutingTable MapGet(string url, HttpResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[HttpMethod.Get][url] = response;

            return this;    //начина, за да върнем RoutingTable; така се връща мапването на url-a към response-a
        }

        public HttpResponse MatchRequest (HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestUrl];
        }
    }
}
