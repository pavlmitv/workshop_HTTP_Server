namespace MyWebServer.Server.Http
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; private set; }  //TODO: init? --> с init можем да сетнем пропърти само при инициализация на обекта; пр:
                    //var response = new Response {StatusCode = HttpStatusCode.OK}
                    //response.StatusCode = HttpStatusCode.{another enum} -> не е възможно, защото StatusCode вече е зададено при иниц. на обекта

        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();

        public string Content { get; private set; }     //TODO: init?
    }
}
