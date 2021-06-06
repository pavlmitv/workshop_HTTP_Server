using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Server.Http
{
    //създаваме колекция от header-и, за да ограничим достъпа до тези header-и ; не трябва да има опция да се трият header-и
   public class HttpHeaderCollection    
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
            => this.headers = new Dictionary<string, HttpHeader>();
    }
}
