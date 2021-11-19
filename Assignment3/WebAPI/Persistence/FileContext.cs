using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Persistence {
    public class FileContext : IData {
        
        private const string AdultsFile = "adults.json";
        private IList<Adult> Adults { get; }

        public FileContext() {
            Adults = File.Exists(AdultsFile) ? ReadData<Adult>(AdultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s) {
            using var jsonReader = File.OpenText(s);
            return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
        }

        public void SaveChanges() {
            var jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions {
                WriteIndented = true
            });
            using (var outputFile = new StreamWriter(AdultsFile, false)) {
                outputFile.Write(jsonAdults);
            }
        }

        public async Task<IList<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex) {
            var tmp = new List<Adult>(Adults);
            if (id != null) tmp = tmp.Where(t => t.Id == id).ToList();
            if (name != null) tmp = tmp.Where(t => (t.FirstName + " " + t.LastName).ToLowerInvariant().Contains(name.ToLower())).ToList();
            if (age != null) tmp = tmp.Where(t => t.Age == age).ToList();
            if (sex != null) tmp = tmp.Where(t => t.Sex == sex).ToList();
            return tmp;
        }

        public async Task<Adult> AddAdultAsync(Adult adult) {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            Adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task DeleteAdultAsync(int AdultId) {
            foreach (var adult in Adults) {
                if (adult.Id == AdultId) {
                    Adults.Remove(adult);
                    return;
                }
            }
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult) {
            foreach (var tmp in Adults) {
                if (tmp.Id == adult.Id) {
                    tmp.FirstName = adult.FirstName;
                    tmp.LastName = adult.LastName;
                    tmp.HairColor = adult.HairColor;
                    tmp.EyeColor = adult.EyeColor;
                    tmp.Age = adult.Age;
                    tmp.Weight = adult.Weight;
                    tmp.Height = adult.Height;
                    tmp.Sex = adult.Sex;
                    return adult;
                }
            }
            return null;
        }
    }
}