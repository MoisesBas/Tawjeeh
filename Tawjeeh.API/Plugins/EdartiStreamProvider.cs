using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Tawjeeh.Api.Plugins
{
    public class EdartiStreamProvider : MultipartFormDataStreamProvider
    {
        public EdartiStreamProvider(string uploadPath)
            : base(uploadPath)
        {

        }


        //public override string GetLocalFileName(HttpContentHeaders headers)
        //{
        //    string fileName = headers.ContentDisposition.FileName;
        //    if (string.IsNullOrWhiteSpace(fileName))
        //    {
        //        fileName = Guid.NewGuid().ToString() + ".data";
        //    }
        //    return fileName.Replace("\"", string.Empty);
        //}

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            // override the filename which is stored by the provider (by default is bodypart_x)
            string oldfileName = headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            string newFileName = System.DateTime.Now.Ticks.ToString() + Path.GetExtension(oldfileName);

            return newFileName;
        }
    }
}