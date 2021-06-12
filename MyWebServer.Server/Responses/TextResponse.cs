using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using System;
using System.Text;

namespace MyWebServer.Server.Responses
{
    public class TextResponse : HttpResponse
    {
        //искаме TextResponse да позволява изпращането на текст (string text) към браузъра
        public TextResponse(string text, string contentType)
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);

            var contentLength = Encoding.UTF8.GetByteCount(text).ToString();
            this.Headers.Add("Content-Length", contentLength);
            this.Headers.Add("Content - Type", contentType);

            this.Content = text;
        }

        public TextResponse(string text)
            : this(text, "text / plain; charset = UTF - 8")
        {
        }
    }
}
