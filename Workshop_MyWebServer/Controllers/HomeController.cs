using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;


namespace Workshop_MyWebServer.Controllers
{
    public class HomeController:Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        {

        }

        public HttpResponse Index()
            => Text("Hello, you are in the homepage!");
    }
}
