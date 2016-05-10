using System;
using System.Collections.Generic;

namespace GiveMeTheRESTClient
{
    public class CompleteMessage: Message
    {
        public object Id { get; set; }
        public CompleteMessage Parent { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public List<CompleteMessage> Childs { get; set; }

        public CompleteMessage() { }

        public CompleteMessage(string name, string value, string date, List<CompleteMessage> childs, CompleteMessage parent = null)
        {
            Name = name;
            Value = value;
            Date = date;
            Childs = childs;
            Parent = parent;
        }
    }
}