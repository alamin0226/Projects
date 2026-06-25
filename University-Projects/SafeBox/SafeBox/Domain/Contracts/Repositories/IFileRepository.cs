using SafeBox.Domain.Entities;
using System.Collections.Generic;

namespace SafeBox.Domain.Contracts.Repositories
{
    public interface IFileRepository
    {
        int Insert(FileEntity file);
        FileEntity GetById(int fileId);
        List<FileEntity> GetByVaultId(int vaultId);
        void DeleteFile(int fileId);
        long GetTotalStorageSize(int userId);
    }
}
