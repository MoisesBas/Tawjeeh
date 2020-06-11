using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.Infrastructure.SMS
{
    
    public class SmsSentMessages : Response
    {
        public SmsSent[] messages { get; set; }
    }
}
