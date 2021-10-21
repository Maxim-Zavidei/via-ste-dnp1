using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JSONFileStorage {
    class PersonPersistence {
        public static void StoreObjects(List<Person> persons) {
            string json = JsonSerializer.Serialize(persons, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText("example.json", json);
        }
        
        public static string ReadJSON(string FileName) {
            return System.IO.File.ReadAllText(FileName);
        }
    }
}