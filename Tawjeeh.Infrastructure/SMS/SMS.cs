using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Tawjeeh.Infrastructure.SMS
{
    public class SMS : ISms
    {
        private Uri uri;
        private string _host { get; set; }
        private string _port { get; set; }
        private string _version { get; set; }
        private string _key { get; set; }
        private string _secret { get; set; }
        private bool _enabled { get; set; }
        private string _from { get; set; }

        public SMS()
        {
            _host = ConfigurationManager.AppSettings["rest_host"];
            Guard.NotNull(_host, "_host");
            _port = ConfigurationManager.AppSettings["rest_port"];
            Guard.NotNull(_port, "_port");
            _version = ConfigurationManager.AppSettings["rest_version"];
            Guard.NotNull(_version, "_version");
            _from = ConfigurationManager.AppSettings["rest_from"];
            Guard.NotNull(_from, "_from");
            _key = ConfigurationManager.AppSettings["rest_key"];
            Guard.NotNull(_key, "_key");
            _secret = ConfigurationManager.AppSettings["rest_secret"];
            Guard.NotNull(_secret, "_secret");
            _enabled = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSMS"]);          

        }
        public async Task<SmsSentMessages> Send(string destination, string message)
        {
            if (!_enabled) return new SmsSentMessages();

            if (!destination.StartsWith("00") || !destination.StartsWith("+"))
                destination = "+" + destination;

            destination = destination.Replace(" ", string.Empty);

            var payload = new
            {
                origin = _from,
                destination = Convert.ToInt64(destination),
                message = message
            };

            HttpResponseMessage response = await Request("sms", payload);

            return await response.Content.ReadAsAsync<SmsSentMessages>();
        }

        private async Task<HttpResponseMessage> Request(string path, Object payload = null, string filter = "")
        {
            using (var client = new HttpClient())
            {
                string credentials = Credentials(path, null == payload ? "GET" : "POST", filter);

                client.BaseAddress = new Uri(string.Format("{0}://{1}", uri.Scheme, uri.Host));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("MAC", credentials);

                HttpResponseMessage response = null == payload ? await client.GetAsync(uri.PathAndQuery) : await client.PostAsJsonAsync(uri.PathAndQuery, payload);

                response.EnsureSuccessStatusCode();

                return response;
            }
        }

        private string Credentials(string path, string method = "GET", string filter = "")
        {
            uri = new Uri(string.Format("https://{0}/{1}/{2}/?{3}", _host, _version, path, filter));

            string timestamp = ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
            string nonce = Guid.NewGuid().ToString("N");
            string mac = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n\n", timestamp, nonce, method, uri.PathAndQuery, uri.Host, _port);

            mac = Convert.ToBase64String((new HMACSHA256(Encoding.ASCII.GetBytes(_secret))).ComputeHash(Encoding.ASCII.GetBytes(mac)));

            return string.Format("id=\"{0}\", ts=\"{1}\", nonce=\"{2}\", mac=\"{3}\"", _key, timestamp, nonce, mac);

        }   

    }
}
