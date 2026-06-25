using SafeBox.BLL.Security;
using SafeBox.BLL.Validators;
using SafeBox.Domain.Contracts.Repositories;
using SafeBox.Domain.DTOs.Auth;
using SafeBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SafeBox.Application.Interfaces;

namespace SafeBox.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IActivityLogRepository _activityRepo;
        //private readonly IAuditLogRepository _auditRepo;
      

        public UserService()
        {
            _repo = new Infrastructure.Repositories.UserRepository();
            _activityRepo = new Infrastructure.Repositories.ActivityLogRepository();
        }

        public UserService(IUserRepository userRepo, IActivityLogRepository activityRepo)
        {
            _activityRepo = activityRepo;
            _repo = userRepo;
        }

        public RegisterResult Register(RegisterRequest req)
        {
            // 1) Validate input
            var error = AuthValidator.ValidateRegister(req);
            if (error != null)
                return new RegisterResult { Success = false, Message = error };

            string username = req.Username.Trim();
            string email = req.Email.Trim().ToLowerInvariant();

            // 2) Business rule: unique username/email
            if (_repo.UsernameExists(username))
                return new RegisterResult { Success = false, Message = "Username already exists." };

            if (_repo.EmailExists(email))
                return new RegisterResult { Success = false, Message = "Email already exists." };

            // 3) Hash password (store as NVARCHAR string)
            string passwordHash = PasswordHasher.HashPassword(req.Password);

            // 4) Create entity
            var user = new User
            {
                // NOTE: তোমার Users table এ user_id IDENTITY নাই,
                // তাই DAL এ Insert(user) তে user_id তৈরি করে দিতে হবে
                // অথবা DB টেবিলে user_id IDENTITY করে নাও।
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                Status = true
            };

            // 5) Save user
            int newUserId = _repo.Insert(user);

            // 6) Logs (Activity + Audit)
            _activityRepo.Insert(new ActivityLog
            {
                UserId = newUserId,
                Action = "REGISTER",
                Details = $"User registered: {username}"
            });

          
            return new RegisterResult
            {
                Success = true,
                Message = "Account created successfully.",
                NewUserId = newUserId
            };
        }

        public LoginResult Login(LoginRequest req)
        {
            var error = AuthValidator.ValidateLogin(req);
            if (error != null)
                return new LoginResult { Success = false, Message = error };

            string input = req.UsernameOrEmail.Trim();

            var user = _repo.GetByUsernameOrEmail(input);
            if (user == null || user.Status == false)
                return new LoginResult { Success = false, Message = "Invalid credentials or inactive account." };

            if (!PasswordHasher.Verify(req.Password, user.PasswordHash))
                return new LoginResult { Success = false, Message = "Invalid credentials." };

            _activityRepo.Insert(new ActivityLog
            {
             
                Action = "LOGIN",
                Details = $"User login: {user.Username}"
            });

            return new LoginResult
            };
        }

        public User GetUserById(int userId)
        {
            // Assuming UserRepository has a GetById method or using GetByUsernameOrEmail with ID string?
            // Let's check UserRepository or add it.
            // For now, use fallback or implement.
            return null; 
        }

        public void UpdateUser(User user)
        {
            // Implementation...
        }

        public int GetTotalUserCount() { return _repo.GetTotalUserCount(); }
        public int GetActiveUserCount() { return _repo.GetActiveUserCount(); }
        public int GetInactiveUserCount() { return _repo.GetInactiveUserCount(); }
    }
}
