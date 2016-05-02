using System.Collections.Generic;

namespace GiveMeTheRESTClient
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public List<Message> Childs { get; set; }

        public Message(string name, string value, string date, List<Message> childs, int id = 0)
        {
            Name = name;
            Value = value;
            Date = date;
            Childs = childs;
            Id = id;
        }
    }
}