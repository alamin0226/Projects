using SafeBox.Application.Interfaces;
using SafeBox.Application.DTOs;
using SafeBox.Domain.Entities;
using SafeBox.Domain.Contracts.Repositories;
using System;

namespace SafeBox.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;

        public AuthService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }

        public Admin AdminLogin(string username, string password)
        {
            var admin = _userRepository.GetAdminByUsername(username);
            if (admin != null && _cryptoService.VerifyPassword(password, admin.PasswordHash))
            {
                if (admin.Status) return admin;
            }
            return null;
        }

        public UserDto Login(string username, string password)
        {
            var user = _userRepository.GetByUsernameOrEmail(username);
            if (user != null && _cryptoService.VerifyPassword(password, user.PasswordHash))
            {
                // In this project status is string '1' or '0'
                if (user.Status == "1")
                {
                    _userRepository.UpdateLastLogin(user.UserId);
                    return new UserDto
                    {
                        UserId = user.UserId,
                        Username = user.Username,
                        Email = user.Email,
                        Status = user.Status,
                        PasswordHash = user.PasswordHash
                        // RoleId should be added to User entity if needed, default 0
                    };
                }
                else
                {
                    throw new Exception("Your account is not active yet. Please wait for admin approval.");
                }
            }
            throw new Exception("Invalid username or password.");
        }
    }
}
