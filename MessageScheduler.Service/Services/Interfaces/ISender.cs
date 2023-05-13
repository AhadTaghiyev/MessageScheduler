using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageScheduler.Service.Services.Interfaces
{
    public interface ISender
    {
        public Task Send(string to,string content);
    }
}
