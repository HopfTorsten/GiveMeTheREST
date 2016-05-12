using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GiveMeTheRESTClient
{
    public class CompleteMessage: Message
    {
        public int Id { get; set; }
        public CompleteMessage Parent { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public Collection<CompleteMessage> Childs { get; set; }

        public CompleteMessage() {
            Childs = new Collection<CompleteMessage>();
        }

        public CompleteMessage(string name, string value, string date, Collection<CompleteMessage> childs, CompleteMessage parent = null)
        {
            Childs = new Collection<CompleteMessage>();
            Name = name;
            Value = value;
            Date = date;
            Childs = childs;
            Parent = parent;
        }
    }
}