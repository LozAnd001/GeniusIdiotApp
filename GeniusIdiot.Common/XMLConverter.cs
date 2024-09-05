using System.IO;
using System.Xml.Serialization;

namespace GeniusIdiot.Common
{
    public class XMLConverter : IConvert
    {
        public string Serialize<T>(T item)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var textWriter =  new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, item);
                return textWriter.ToString();
            }
        }

        public T Deserialize<T>(string data)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var textReader = new StringReader(data))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
    }
}