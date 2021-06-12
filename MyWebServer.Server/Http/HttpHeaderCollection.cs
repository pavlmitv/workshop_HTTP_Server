using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyWebServer.Server.Http
{
    //създаваме колекция от header-и, за да ограничим достъпа до тези header-и ; не трябва да има опция да се трият header-и
    public class HttpHeaderCollection : IEnumerable<HttpHeader> // декларираме, че колекцията е IEnumerable и имплементираме интерфейса (по-надолу)
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
            => this.headers = new Dictionary<string, HttpHeader>();

        public int Count => this.headers.Count;
        public void Add(string name, string value)
        {
            var header = new HttpHeader(name, value);
            this.headers.Add(name, header);
        }

        public IEnumerator<HttpHeader> GetEnumerator()
            => this.headers.Values.GetEnumerator(); // взимаме всички values и ги връщаме като Enumerator

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
