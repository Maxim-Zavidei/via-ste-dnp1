using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data.Impl {
    public class SqliteAdultService : IData {
        
        private AdultContext Context;

        public SqliteAdultService(AdultContext context) {
            this.Context = context;
        }
        
        public async Task<IList<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex) {
            var toReturn = Context.Adults.ToList();
            var toRemove = new List<Adult>();

            if (id != null) {
                foreach (var adult in toReturn) {
                    if (adult.Id != id) toRemove.Add(adult);
                }
            }
            
            if (name != null) {
                foreach (var adult in toReturn) {
                    if (adult.FirstName + adult.LastName != name) toRemove.Add(adult);
                }
            }

            if (age != null) {
                foreach (var adult in toReturn) {
                    if (adult.Age != age) toRemove.Add(adult);
                }
            }
            
            if (sex != null) {
                foreach (var adult in toReturn) {
                    if (adult.Sex != sex) toRemove.Add(adult);
                }
            }

            foreach (var adult in toRemove) toReturn.Remove(adult); 
            return toReturn;
        }

        public async Task<Adult> AddAdultAsync(Adult adult) {
            Context.Adults.AddAsync(adult);
            return adult;
        }

        public async Task DeleteAdultAsync(int AdultId) {
            Adult adult = Context.Adults.Where(a => a.Id == AdultId).First();
            Context.Remove(adult);
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult) {
            Context.Adults.Update(adult);
            return adult;
        }
    }
}