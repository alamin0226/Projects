using SafeBox.Domain.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SafeBox.BLL.Validators
{
    public static class AuthValidator
    {
        public static string ValidateRegister(RegisterRequest req)
        {
            if (req == null) return "Request is null.";

            if (string.IsNullOrWhiteSpace(req.Username))
                return "Username is required.";

            if (req.Username.Trim().Length < 3)
                return "Username must be at least 3 characters.";

            if (string.IsNullOrWhiteSpace(req.Email))
                return "Email is required.";

            if (!IsValidEmail(req.Email))
                return "Invalid email format.";

            if (string.IsNullOrWhiteSpace(req.Password))
                return "Password is required.";

            if (req.Password.Length < 6)
                return "Password must be at least 6 characters.";

            if (req.Password != req.ConfirmPassword)
                return "Password and Confirm Password do not match.";

            return null;
        }

        public static string ValidateLogin(LoginRequest req)
        {
            if (req == null) return "Request is null.";

            if (string.IsNullOrWhiteSpace(req.UsernameOrEmail))
                return "Username or Email is required.";

            if (string.IsNullOrWhiteSpace(req.Password))
                return "Password is required.";

            return null;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email.Trim(),
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }
    }
}
