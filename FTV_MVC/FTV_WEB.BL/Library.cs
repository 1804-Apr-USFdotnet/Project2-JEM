using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace FTV_WEB.BL
{
    public static class Library
    {
        public static string Serialize<T>(T type)
        {
            return JsonConvert.SerializeObject(type, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All
            });
        }

        public static IEnumerable<T> Deserialize<T>(string list)
        {
            return JsonConvert.DeserializeObject<List<T>>(list, new JsonSerializerSettings
            {
//                PreserveReferencesHandling = PreserveReferencesHandling.All
                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public static string AsJsonList<T>(List<T> tt)
        {
            return new JavaScriptSerializer().Serialize(tt);
        }
        public static string AsJson<T>(T t)
        {
            return new JavaScriptSerializer().Serialize(t);
        }
        public static List<T> AsObjectList<T>(string tt)
        {
            return new JavaScriptSerializer().Deserialize<List<T>>(tt);
        }
        public static T AsObject<T>(string t)
        {
            return new JavaScriptSerializer().Deserialize<T>(t);
        }
    }
}
