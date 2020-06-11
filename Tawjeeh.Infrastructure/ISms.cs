using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Infrastructure.SMS;

namespace Tawjeeh.Infrastructure
{
    public interface ISms
    {
        Task<SmsSentMessages> Send(string destination, string message);
    }

}
