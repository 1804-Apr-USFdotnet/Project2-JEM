using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FTV.BL
{
    public class Serializer
    {
        public static void Serialize(object type, string filename = "")
        {
            filename = filename ?? "data.json";
            string path = $"~/logs/{filename}";

            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            using (var streamWriter = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, type);
            }
        }

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