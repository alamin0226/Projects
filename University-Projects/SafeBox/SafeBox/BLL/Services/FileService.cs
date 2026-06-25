using System;
using System.Collections.Generic;
using System.IO;
using SafeBox.BLL.Security;
using SafeBox.DAL.Repositories;
using SafeBox.Domain.Entities;

using SafeBox.Application.Interfaces;

namespace SafeBox.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly string _storageRoot;

        public FileService()
        {
            _fileRepository = new Infrastructure.Repositories.FileRepository();
            // Store encrypted files in a specific folder
            _storageRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EncryptedStorage");
            if (!Directory.Exists(_storageRoot))
            {
                Directory.CreateDirectory(_storageRoot);
            }
        }

        /// <summary>
        /// Reads a file, encrypts it, saves it to disk, and records metadata in DB.
        /// </summary>
        public void UploadFile(string sourceFilePath, int vaultId, int userId, string userPassword)
        {
            if (!System.IO.File.Exists(sourceFilePath))
                throw new FileNotFoundException("Source file not found.");

            byte[] originalBytes = System.IO.File.ReadAllBytes(sourceFilePath);
            byte[] encryptedBytes = EncryptionService.EncryptData(originalBytes, userPassword);

            string safeFileName = EncryptionService.GenerateRandomFileName(".enc");
            string storagePath = Path.Combine(_storageRoot, safeFileName);

            System.IO.File.WriteAllBytes(storagePath, encryptedBytes);

            var fileEntity = new FileEntity
            {
                VaultId = vaultId,
                UserId = userId,
                FileName = Path.GetFileName(sourceFilePath),
                FilePath = storagePath,
                FileSize = encryptedBytes.Length,
                IsEncrypted = true,
                UploadedAt = DateTime.Now
            };

            _fileRepository.Insert(fileEntity);
        }

        public byte[] DownloadFile(int fileId, string userPassword)
        {
            var fileEntity = _fileRepository.GetById(fileId);
            if (fileEntity == null)
                throw new Exception("File record not found.");

            if (!System.IO.File.Exists(fileEntity.FilePath))
                throw new FileNotFoundException("Encrypted file missing from storage.");

            byte[] encryptedBytes = System.IO.File.ReadAllBytes(fileEntity.FilePath);
            return EncryptionService.DecryptData(encryptedBytes, userPassword);
        }

        public List<FileEntity> GetFiles(int vaultId)
        {
            return _fileRepository.GetByVaultId(vaultId);
        }

        public IEnumerable<FileEntity> GetAllFiles(int userId)
        {
            // Assuming we need a method to get all files for a user across all vaults
            // This might need a new method in repo. For now, empty or implement.
            return new List<FileEntity>(); 
        }

        public void DeleteFile(int fileId)
        {
            var file = _fileRepository.GetById(fileId);
            if (file != null)
            {
                if (System.IO.File.Exists(file.FilePath))
                {
                    System.IO.File.Delete(file.FilePath);
                }
                _fileRepository.DeleteFile(fileId);
            }
        }

        public long GetTotalStorageSize(int userId)
        {
            return _fileRepository.GetTotalStorageSize(userId);
        }
    }
}
