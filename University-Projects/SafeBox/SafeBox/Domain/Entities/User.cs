using System;

namespace SafeBox.Domain.Entities
{
    /// <summary>
    /// Represents a user in the SafeBox system.
    /// Maps to Users table.
    /// </summary>
    public class User
    {
        public string Username { get; set; } = "";// user_username
        public int UserId { get; set; }   
        public string Email { get; set; } = "";         // email
        public string PasswordHash { get; set; } = "";  // password_hash
        public string Status { get; set; }                // status
        public DateTime CreatedAt { get; set; }          // created_at
        public DateTime UpdateLastLogin { get; set; }
    }
}
