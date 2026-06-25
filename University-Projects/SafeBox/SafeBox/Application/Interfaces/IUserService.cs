using SafeBox.Domain.Entities;
using SafeBox.Domain.DTOs.Auth;

namespace SafeBox.Application.Interfaces
{
    public interface IUserService
    {
        int GetTotalUserCount();
        int GetActiveUserCount();
        int GetInactiveUserCount();
        RegisterResult Register(RegisterRequest req);
        LoginResult Login(LoginRequest req);
        User GetUserById(int userId);
        void UpdateUser(User user);
    }
}
