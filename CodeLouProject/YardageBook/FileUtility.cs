using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
