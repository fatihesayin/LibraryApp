
using Newtonsoft.Json;

namespace LibraryApp.CrossCutting
{
    public static class JsonHelper
    {
        public static string ToJson(this object obje, JsonSerializerSettings? settings = null)
        {
            return JsonConvert.SerializeObject(obje, settings);
        }
        public static T? ToObject<T>(this string jsonTypeString, JsonSerializerSettings? settings = null)
        {
            return JsonConvert.DeserializeObject<T>(jsonTypeString, settings);
        }
        public static T? MapManual<T>(this object obje)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obje));
        }
    }
}
