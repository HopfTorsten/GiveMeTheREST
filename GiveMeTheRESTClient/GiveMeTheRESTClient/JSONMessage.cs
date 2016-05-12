using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveMeTheRESTClient
{
    public class JSONMessage : Message
    {
        public string content { get; set; }
        public object id { get { return this.idValue; } set { this.idValue = (value == null) ? this.idValue = 0 : this.idValue = Convert.ToInt32(value); } }
        public object parent { get { return this.parentValue; } set{ this.parentValue = (value == null) ? this.parentValue = 0 : this.parentValue = Convert.ToInt32(value); } } 
        private int idValue;
        private int parentValue;
    }
}
