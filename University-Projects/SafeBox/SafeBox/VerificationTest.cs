using System;
using System.IO;
using System.Text;
using SafeBox.BLL.Services;
using SafeBox.DAL.Repositories;
using SafeBox.Domain.Entities;
using SafeBox.Infrastructure.Repositories; // For UserRepository

namespace SafeBox.Verification
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== SafeBox Verification Test ===");
                
                // 1. Setup Services
                var userRepo = new UserRepository();
                var vaultService = new VaultService();
                var fileService = new FileService();

                // 2. Create User (or get existing)
                string username = "testuser_" + new Random().Next(1000);
                string password = "StrongPassword123!";
                Console.WriteLine($"Registering User: {username}");
                
                // (Note: Using existing logic - hoping IUserRepository is consistent)
                var user = new User
                {
                    Username = username,
                    Email = $"{username}@test.com",
                    PasswordHash = password // In real app, hash this!
                };
                
                // Assuming Insert returns ID
                int userId = userRepo.Insert(user);
                Console.WriteLine($"User Created. ID: {userId}");

                // 3. Create Vault
                Console.WriteLine("Creating Vault...");
                vaultService.CreateVault("My Secret Vault", "Top Secret", userId);
                
                var vaults = vaultService.GetUserVaults(userId);
                if (vaults.Count == 0) throw new Exception("Vault creation failed!");
                int vaultId = vaults[0].VaultId;
                Console.WriteLine($"Vault Created. ID: {vaultId}");

                // 4. Create dummy file
                string testFile = "secret_message.txt";
                string content = "This is a classified message requiring AES-256 encryption.";
                System.IO.File.WriteAllText(testFile, content);

                // 5. Upload File (Encrypt)
                Console.WriteLine("Uploading File (Encrypting)...");
                fileService.UploadFile(testFile, vaultId, userId, password);
                
                var files = fileService.GetFiles(vaultId);
                if (files.Count == 0) throw new Exception("File upload failed!");
                int fileId = files[0].FileId;
                Console.WriteLine($"File Uploaded. ID: {fileId}, Encrypted Path: {files[0].FilePath}");

                // 6. Download File (Decrypt)
                Console.WriteLine("Downloading File (Decrypting)...");
                byte[] decryptedBytes = fileService.DownloadFile(fileId, password);
                string decryptedContent = Encoding.UTF8.GetString(decryptedBytes);

                // 7. Verify
                Console.WriteLine($"Original Content:  {content}");
                Console.WriteLine($"Decrypted Content: {decryptedContent}");

                if (content == decryptedContent)
                {
                    Console.WriteLine("SUCCESS: Content matches!");
                }
                else
                {
                    Console.WriteLine("FAILURE: Content Mismatch!");
                }

                // Cleanup
                // fileService.DeleteFile(fileId);
                // vaultService.RemoveVault(vaultId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
