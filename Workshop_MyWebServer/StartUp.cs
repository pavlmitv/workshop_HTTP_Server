using System.Threading.Tasks;
using MyWebServer.Server;
using MyWebServer.Server.Responses;

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
                                        .MapGet("/", new TextResponse("Hello, you are in the homepage!"))
                                        .MapGet("/Cats", request =>
                                        {
                                            var query = request.Query;
                                            var catName = query.ContainsKey("Name")
                                            ? query["Name"]
                                            : "the cats";

                                            var result = $"<h1>Hello from {catName}!</h1>";
                                            return new HtmlResponse(result);
                                        })
                                        .MapGet("/Dogs", new HtmlResponse("<h1>Dogs page..</h1>")));

            await server.Start();

        }
    }
}
