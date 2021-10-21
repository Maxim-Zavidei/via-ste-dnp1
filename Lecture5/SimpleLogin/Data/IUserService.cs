using SimpleLogin.Models;

namespace SimpleLogin.Data {
    public interface IUserService {
        User ValidateUser(string userName, string Password);
    }
}