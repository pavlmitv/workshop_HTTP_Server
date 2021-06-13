using MyWebServer.Server.Http;

namespace MyWebServer.Server.Responses
{
    class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse()
            : base(HttpStatusCode.BadRequest)
        {

        }
    }
}
