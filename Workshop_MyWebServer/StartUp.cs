using System.Threading.Tasks;
using MyWebServer.Server;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace Workshop_MyWebServer
{
    public class StartUp
    {

        public static async Task Main()
        {
            // https://localhost:8090

            var server = new HttpServer(routs => routs
                                        .MapGet("/", new TextResponse("Hello, you are in the homepage!"))
                                        .MapGet("/Cats", new TextResponse("<h1>Cats page..</h1>", "text/html")) //Може да приема и html
                                        .MapGet("/Dogs", new TextResponse("<h1>Dogs page..</h1>", "text/html")));

            await server.Start();

        }
    }
}
