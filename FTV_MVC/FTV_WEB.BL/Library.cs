using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FTV_WEB.BL
{
    public static class Library
    {
        public static string Serialize<T>(T type)
        {
            return JsonConvert.SerializeObject(type);
        }

        public static List<T> Deserialize<T>(string filename)
        {
            var jsonFile = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<List<T>>(jsonFile);
        }
    }
}
