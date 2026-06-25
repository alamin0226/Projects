using SafeBox.Domain.Entities;
using System.Collections.Generic;

namespace SafeBox.Application.Interfaces
{
    public interface IFileService
    {
        long GetTotalStorageSize(int userId);
        IEnumerable<FileEntity> GetAllFiles(int userId);
        void UploadFile(string sourceFilePath, int vaultId, int userId, string userPassword);
        byte[] DownloadFile(int fileId, string userPassword);
        List<FileEntity> GetFiles(int vaultId);
        void DeleteFile(int fileId);
    }
}
