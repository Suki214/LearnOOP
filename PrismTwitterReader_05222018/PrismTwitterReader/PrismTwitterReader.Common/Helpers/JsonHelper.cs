using System.IO;
using Newtonsoft.Json;

namespace PrismTwitterReader.Common
{
    public static class JsonHelper
    {
        public static string SerializeObjectAsJsonString(object objectToSerialize)
        {
            string jsonString = JsonConvert.SerializeObject(objectToSerialize, Newtonsoft.Json.Formatting.Indented
                                    , new JsonSerializerSettings
                                            {
                                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                            }
                                    );
            return jsonString;
        }

        public static void SaveAsJsonToFile(object objectToSerialize, string filePath)
        {
            string jsonString = SerializeObjectAsJsonString(objectToSerialize);
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                File.WriteAllText(filePath, jsonString);
            }
        }      

        public static T DeserializeToClass<T>(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                return default(T);

            T @class = JsonConvert.DeserializeObject<T>(jsonString);
            return @class;
        }

        public static T DeserializeFromFile<T>(string jsonfilePath)
        {
            string jsonString = File.ReadAllText(jsonfilePath);
            if (string.IsNullOrWhiteSpace(jsonString))
                return default(T);

            T @class = JsonConvert.DeserializeObject<T>(jsonString);
            return @class;
        }

        public static bool IsMatchingJsonFormat(this string json)
        {
            return !string.IsNullOrEmpty(json) && json.Length >= 2 && ((json[0] == '{' && json[json.Length - 1] == '}') || (json[0] == '[' && json[json.Length - 1] == ']'));
        }
    }
}
