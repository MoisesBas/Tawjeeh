using System.IO;
using System.Net.Http;

namespace Tawjeeh.Api.Common
{
    public class StreamProvider : MultipartFormDataStreamProvider
    {
        public StreamProvider(string uploadPath)
            : base(uploadPath)
        {
        }

        /// <summary>
        /// Gets the name of the local file.
        /// </summary>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string oldfileName = headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            string newFileName = System.DateTime.Now.Ticks.ToString() + Path.GetExtension(oldfileName);

            return newFileName;
        }
    }
}