using System;
using System.IO;
using System.Text.Json;

namespace YardageBook
{
    public static class FileUtility
    {
        public static T ReadJsonFile<T> (string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public static void SaveJsonFile (object input, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(input);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
