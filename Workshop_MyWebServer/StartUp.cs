using System.Threading.Tasks;
using MyWebServer.Server;
using MyWebServer.Server.Responses;
using Workshop_MyWebServer.Controllers;

namespace Workshop_MyWebServer
{
    public class StartUp
    {
        // /Cats -> Hello from the cats!
        // /Cats?Name=Sharo -> Hello from Sharo!
        public static async Task Main()
        {
            // https://localhost:8090

            var server = new HttpServer(routs => routs
                                        .MapGet("/", request => new HomeController(request).Index())
                                        .MapGet("/Cats", request => new AnimalsController(request).Cats())
                                        .MapGet("/Dogs", request => new AnimalsController(request).Dogs())
                                        .MapGet("/Softuni", request => new HomeController(request).ToSoftUni()));

            await server.Start();

        }
    }
}

