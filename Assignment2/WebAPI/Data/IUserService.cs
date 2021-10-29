using WebAPI.Models;

namespace WebAPI.Data {
    public interface IUserService {
        User ValidateUser(string UserName, string Password);
        bool IsEmailRegistered(string email);
        void RegisterUser(User user);
    }
}