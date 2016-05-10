using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveMeTheRESTClient
{
    public class JSONMessage: Message
    {
        public string content { get; set; }
        public object id { get; set; }
        public object parent { get; set; }
    }
}
