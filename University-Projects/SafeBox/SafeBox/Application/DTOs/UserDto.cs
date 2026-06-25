using System;

namespace SafeBox.Application.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int RoleId { get; set; }
        public string PasswordHash { get; set; }
    }
}
