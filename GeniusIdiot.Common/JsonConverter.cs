using Newtonsoft.Json;

namespace GeniusIdiot.Common
{
    public class JsonConverter : IConvert
    {
        public string Serialize<T>(T item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        } 
    }
}