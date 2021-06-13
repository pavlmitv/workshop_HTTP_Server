namespace MyWebServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        //искаме TextResponse да позволява изпращането на текст (string text) към браузъра
        public TextResponse(string text)
            : base(text, "text/plain; charset = UTF - 8")
        {
        }
    }
}
