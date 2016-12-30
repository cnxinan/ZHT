using Newtonsoft.Json;

namespace ZHT.Framework
{
    public class JsonHelper
    {
        public static string ConvertToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
