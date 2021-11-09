using System.Threading.Tasks;
using TodoDatabase.Models;

namespace TodoDatabase.Data {
    public interface IUserService {
        Task<User> ValidateUser(string userName, string passWord);
    }
}