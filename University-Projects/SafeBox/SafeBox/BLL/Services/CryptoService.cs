using SafeBox.Application.Interfaces;
using SafeBox.BLL.Security;

namespace SafeBox.Application.Services
{
    public class CryptoService : ICryptoService
    {
        public string HashPassword(string password)
        {
            return PasswordHasher.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return PasswordHasher.Verify(password, hash);
        }
    }
}
