using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.Infrastructure.SMS
{
    [Serializable()]
    public class SmsSent : Response
    {
        public string id { get; set; }
        public string outgoing_id { get; set; }
        public string origin { get; set; }
        public string message { get; set; }
        public string dateTime { get; set; }
        public string status { get; set; }
    }
}
