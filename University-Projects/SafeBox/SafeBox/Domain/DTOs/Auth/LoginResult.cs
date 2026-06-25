using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.DTOs.Auth
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public int? UserId { get; set; }
        public string Username { get; set; }
    }
}
