using System.Threading.Tasks;
using Application.Models;

namespace Application.Data {
    public interface IUserService {
        Task<User> ValidateUser(string UserName, string Password);
        Task RegisterUser(User user);
    }
}