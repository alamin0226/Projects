using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SafeBox.BLL.Security
{
    public class EncryptionService
    {
        // Salt for key derivation (In a real app, this should be unique per user and stored in DB)
        private static readonly byte[] Salt = Encoding.UTF8.GetBytes("SafeBox_Secure_Salt_2024");

        /// <summary>
        /// Encrypts bytes using AES-256
        /// </summary>
        public static byte[] EncryptData(byte[] data, string password)
        {
            if (data == null || data.Length == 0) return null;

            using (Aes aes = Aes.Create())
            {
                // Derive key and IV from password
                using (var keyDerivation = new Rfc2898DeriveBytes(password, Salt, 10000))
                {
                    aes.Key = keyDerivation.GetBytes(32); // 256 bits
                    aes.IV = keyDerivation.GetBytes(16);  // 128 bits
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.Close();
                    }
                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Decrypts bytes using AES-256
        /// </summary>
        public static byte[] DecryptData(byte[] data, string password)
        {
            if (data == null || data.Length == 0) return null;

            using (Aes aes = Aes.Create())
            {
                // Derive key and IV from password (must match encryption)
                using (var keyDerivation = new Rfc2898DeriveBytes(password, Salt, 10000))
                {
                    aes.Key = keyDerivation.GetBytes(32);
                    aes.IV = keyDerivation.GetBytes(16);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.Close();
                    }
                    return ms.ToArray();
                }
            }
        }
        
        /// <summary>
        /// Generates a random file name to prevent collision and inferring content from name
        /// </summary>
        public static string GenerateRandomFileName(string extension)
        {
            return Guid.NewGuid().ToString() + extension;
        }
    }
}
