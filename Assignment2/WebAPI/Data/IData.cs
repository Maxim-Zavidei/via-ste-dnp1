using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data {
    public interface IData {
        Task<IList<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex);
        Task<Adult> AddAdultAsync(Adult adult);
        Task DeleteAdultAsync(int AdultId);
        Task<Adult> UpdateAdultAsync(Adult adult);
    }
}