using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebServer.Server.Http
{
    public class HttpRequest
    {
        //http messages --> https://developer.mozilla.org/en-US/docs/Web/HTTP/Messages#http_requests

        private const string NewLine = "\r\n";
        public HttpMethod Method { get; private set; }
        public string Path { get; private set; }
        public HttpHeaderCollection Headers { get; private set; }
        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {
            string[] lines = request.Split(NewLine[0]);

            var startLine = lines.First().Split(" "[0]);

            var method = ParseHttpMethod(startLine[0]);

            var url = startLine[1];

            var headers = ParseHttpHeaderCollection(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join(NewLine, bodyLines);

            return new HttpRequest
            {
                Method = method,
                Path = url,
                Headers = headers,
                Body = body,
            };
        }

        private static HttpHeaderCollection ParseHttpHeaderCollection(IEnumerable<string> headerLines)
        {
            var headerCollection = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }
                var indexOfSemicolumns = headerLine.IndexOf(":");
                if (indexOfSemicolumns<0)
                {
                    throw new InvalidOperationException("Request isn't valid");
                }

                var header = new HttpHeader
                {
                    Name = headerLine.Substring(0, indexOfSemicolumns),
                    Value = headerLine.Substring(indexOfSemicolumns + 1).Trim()
                };
                headerCollection.Add(header);
            }

            return headerCollection;
        }

        private static HttpMethod ParseHttpMethod(string method)
        {
            switch (method.ToUpper())
            {
                case "GET":
                    return HttpMethod.Get;
                    break;
                case "DELETE":
                    return HttpMethod.Delete;
                    break;
                case "POST":
                    return HttpMethod.Post;
                    break;
                case "PUT":
                    return HttpMethod.Put;
                    break;
                default:
                    throw new InvalidOperationException($"Method {method} is not supported.");
            }
        }
        //private static string[] GetStartLine (string request)
        //{

        //}
    }
}
