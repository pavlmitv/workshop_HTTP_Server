using System.Threading.Tasks;
using MyWebServer.Server;

namespace Workshop_MyWebServer
{
    public class StartUp
    {

        public static async Task Main()
        {

            // https://localhost:8090

            var server = new HttpServer("127.0.0.1", 8090);

            await server.Start();

        }
    }
}
