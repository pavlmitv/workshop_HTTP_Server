using System;
using System.Collections.Generic;

namespace MyWebServer.Server.Http
{
    public class HttpRequest
    {
        //http messages --> https://developer.mozilla.org/en-US/docs/Web/HTTP/Messages#http_requests

        public HttpMethod Method { get; private set; }
        public string Path { get; private set; }
        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();
        public string Body { get; private set; }
    }
}
