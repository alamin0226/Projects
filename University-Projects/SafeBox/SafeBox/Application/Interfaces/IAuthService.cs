using SafeBox.Domain.Entities;
using SafeBox.Application.DTOs;

namespace SafeBox.Application.Interfaces
{
    public interface IAuthService
    {
        Admin AdminLogin(string username, string password);
        UserDto Login(string username, string password);
    }
}
