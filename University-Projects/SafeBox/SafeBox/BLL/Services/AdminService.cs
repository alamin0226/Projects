using SafeBox.BLL.Security;
using SafeBox.Domain.Contracts.Repositories;
using SafeBox.Domain.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Application.Services
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepo;
        private readonly IAuditLogRepository _auditRepo;

        public AdminService(IAdminRepository adminRepo, IAuditLogRepository auditRepo)
        {
            _adminRepo = adminRepo;
            _auditRepo = auditRepo;
        }

        public LoginResult Login(LoginRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.UsernameOrEmail) || string.IsNullOrWhiteSpace(req.Password))
                return new LoginResult { Success = false, Message = "Username/Email and Password required." };

            var admin = _adminRepo.GetByUsernameOrEmail(req.UsernameOrEmail.Trim());
            if (admin == null || admin.Status == false)
                return new LoginResult { Success = false, Message = "Invalid credentials or inactive admin." };

            if (!PasswordHasher.Verify(req.Password, admin.PasswordHash))
                return new LoginResult { Success = false, Message = "Invalid credentials." };

            _auditRepo.Insert(new SafeBox.Domain.Entities.AuditLog
            {
                UserId = null,
                AdminId = admin.AdminId,
                Action = "ADMIN_LOGIN",
                Details = $"Admin login: {admin.AdminUsername}"
            });

            return new LoginResult
            {
                Success = true,
                Message = "Admin login successful.",
                UserId = null,
                Username = admin.AdminUsername
            };
        }
    }
}
