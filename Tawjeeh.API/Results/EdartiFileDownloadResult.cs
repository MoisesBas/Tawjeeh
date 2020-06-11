using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Tawjeeh.Api.Results
{
    public class EdartiFileDownloadResult : IHttpActionResult
    {

        private readonly string _filePath;
        private readonly string _contentType;
        private readonly string _fileName;

        public EdartiFileDownloadResult(string filePath, string fileName, string contentType = null)
        {
            if (filePath == null) throw new ArgumentNullException("filePath");

            _filePath = filePath;
            _contentType = contentType;
            _fileName = fileName;
        }



        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(File.OpenRead(_filePath))
                };                              
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");              
                response.Content.Headers.Add("Content-Disposition", new[] { "attachment; filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8) });

                return response;

            }, cancellationToken);
        }

    }
}