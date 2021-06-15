﻿using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_MyWebServer.Controllers
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
            => this.Request = request;
        protected HttpRequest Request { get; private init; }
        protected HttpResponse Text(string text)
            => new TextResponse(text);

        protected HttpResponse Html(string html) => new HtmlResponse(html);
    }
}
