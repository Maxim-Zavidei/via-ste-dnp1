using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Data {
    public interface IData {
        Task<IList<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex);
        Task<Adult> AddAdultAsync(Adult adult);
    }
}