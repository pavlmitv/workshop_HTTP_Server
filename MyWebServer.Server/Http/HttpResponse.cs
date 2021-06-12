using System;
using System.Text;

namespace MyWebServer.Server.Http
{
    public abstract class HttpResponse
    {

        public HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers.Add("Server", "My web server");
            this.Headers.Add("Date", $"{ DateTime.UtcNow:r}");
        }
        public HttpStatusCode StatusCode { get; init; }  //TODO: init? --> с init можем да сетнем пропърти само при инициализация на обекта; пр:
                                                         //var response = new Response {StatusCode = HttpStatusCode.OK}
                                                         //response.StatusCode = HttpStatusCode.{another enum} -> не е възможно, защото StatusCode вече е зададено при иниц. на обекта

        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();

        public string Content { get; init; }

        public override string ToString()
        {
            //метод, за да върнем Response в чист вид като string:
            //HTTP / 1.1 200 OK
            //Server: My web server
            // Date: { DateTime.UtcNow:r}
            //Content - Length: { contentlength}
            //Content - Type: text / html; charset = UTF - 8

            //{ content}
            //";

            var result = new StringBuilder();
            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");  //-->HTTP/1.1 200 OK

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }
            result.AppendLine();
            result.Append(this.Content);

            return result.ToString();
        }
    }
}
