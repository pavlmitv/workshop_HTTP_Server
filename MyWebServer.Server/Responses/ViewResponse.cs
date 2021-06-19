using MyWebServer.Server.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Responses
{
    public class ViewResponse : HttpResponse
    {
        private readonly string filePath;

        public ViewResponse(string filePath) : base(HttpStatusCode.OK)
        {
            this.GetHtml(filePath);
        }

        private void GetHtml(string filePath)
        {
            var directory =  Directory.GetCurrentDirectory();
            var viewPath = Path.Combine(directory, filePath);
            if (!File.Exists(viewPath))
            {
                this.StatusCode = HttpStatusCode.Notfound;
                return;
                var text = File.ReadAllText(filePath);
            }
        }
    }
}
