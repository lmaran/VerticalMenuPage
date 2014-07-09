using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web.Helpers
{
    /// <summary>
    /// This helper reads a simple html file, converts to a string and then returns it as "text/html" HTTP response
    /// </summary>
    public class HtmlActionResult : IHttpActionResult
    {
        private static readonly string _rootPath = HeliosHostingEnvironment.MapPath("~/App"); // HostingEnvironment -  doesn't run in Helios

        private readonly string _fileName;
        private readonly HttpRequestMessage _request;

        public HtmlActionResult(HttpRequestMessage request, string fileName)
        {
            _fileName = fileName;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            string filePath = Path.Combine(_rootPath, _fileName);
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new StreamContent(File.OpenRead(filePath));

            response.Content.Headers.Add("Content-Type", "text/html; charset=utf-8");
            return Task.FromResult(response);
        }

    }
}