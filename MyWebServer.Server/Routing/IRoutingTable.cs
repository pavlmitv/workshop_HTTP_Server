using MyWebServer.Server.Http;
using System;

namespace MyWebServer.Server.Routing
{
    // преизползваме методи, главния е Map; това е стандартна практика
    public interface IRoutingTable
    {
        //методите не са void, а IRoutingTable, за да можем в StartUp класа, когато създаваме сървъра да мапнем няколко искаме пъти; ако са void ще може да се мапне само веднъж;
        IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction); //ако се ползва само .Map -> трябва да се подаде метода ръчно; ако не -> следва да се позлва .MapGet, .MapPost и тн. каквито други методи имаме;
        IRoutingTable MapGet(string path, HttpResponse response);
        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction);
        IRoutingTable MapPost(string path, HttpResponse response);
        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction);

    }
}
