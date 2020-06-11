using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace Tawjeeh.Api.Plugins
{
    public class UriCombine : System.Uri
    {
        
        public UriCombine(string uriString)
            : base(uriString)
        {
        }

       
        [Obsolete(
            "The constructor has been deprecated. Please use new Uri(string). The dontEscape parameter is deprecated and is always false. http://go.microsoft.com/fwlink/?linkid=14202"
            )]

        public UriCombine(string uriString, bool dontEscape) : base(uriString, dontEscape)
        {
        }

      
        [Obsolete(
            "The constructor has been deprecated. Please new Uri(Uri, string). The dontEscape parameter is deprecated and is always false. http://go.microsoft.com/fwlink/?linkid=14202"
            )]

        public UriCombine(UriCombine baseUri, string relativeUri, bool dontEscape) : base(baseUri, relativeUri, dontEscape)
        {
        }

       
        public UriCombine(string uriString, UriKind uriKind)
            : base(uriString, uriKind)
        {
           
        }

        public UriCombine(UriCombine baseUri, string relativeUri)

            : base(baseUri, relativeUri)
        {
        }

        public UriCombine(UriCombine baseUri, UriCombine relativeUri)
            : base(baseUri, relativeUri)
        {
        }

       
        protected UriCombine(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        
        public static string Combine(params string[] parts)
        {
            if (parts == null || parts.Length == 0) return string.Empty;

            var urlBuilder = new StringBuilder();
            foreach (var part in parts)
            {
                var tempUrl = tryCreateRelativeOrAbsolute(part);
                urlBuilder.Append(tempUrl);
            }
            return VirtualPathUtility.RemoveTrailingSlash(urlBuilder.ToString());
        }

        private static string tryCreateRelativeOrAbsolute(string s)
        {
            System.Uri uri;
            TryCreate(s, UriKind.RelativeOrAbsolute, out uri);
            string tempUrl = VirtualPathUtility.AppendTrailingSlash(uri.ToString());
            return tempUrl;
        }
    }
}