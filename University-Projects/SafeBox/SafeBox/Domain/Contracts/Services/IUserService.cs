using SafeBox.Domain.DTOs.Auth;
using SafeBox.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SafeBox.Domain.Contracts.Services
{
    public interface IUserService
    {
        RegisterResult Register(RegisterRequest req);
        LoginResult Login(LoginRequest req);
    }
}
