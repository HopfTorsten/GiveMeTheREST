using System;
using System.Collections.Generic;

namespace GiveMeTheRESTClient
{
    public class Message
    {
        public Message Parent { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public List<Message> Childs { get; set; }

        public Message(string name, string value, string date, List<Message> childs, Message parent = null)
        {
            Name = name;
            Value = value;
            Date = date;
            Childs = childs;
            Parent = parent;
        }
    }
}