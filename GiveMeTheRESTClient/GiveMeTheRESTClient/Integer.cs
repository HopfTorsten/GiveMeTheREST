
namespace GiveMeTheRESTClient
{
    public class Integer
    {
        public int Value { get; set; }

        public Integer(object value)
        {
            if (value == null)
                value = 0;
            Value = (int)value;
        }
    }
}
