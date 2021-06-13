using MyWebServer.Server.Http;

namespace MyWebServer.Server.Routing
{
    public interface IRoutingTable
    {
        //методите не са void, а IRoutingTable, за да можем в StartUp класа, когато създаваме сървъра да мапнем няколко искаме пъти; ако са void ще може да се мапне само веднъж;
        IRoutingTable Map(HttpMethod method, string path, HttpResponse response); //ако се ползва само .Map -> трябва да се подаде метода ръчно; ако не -> следва да се позлва .MapGet, .MapPost и тн. каквито други методи имаме;
        IRoutingTable MapGet(string path, HttpResponse response);

    }
}
