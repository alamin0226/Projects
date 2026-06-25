using SafeBox.Domain.Entities;
using System.Collections.Generic;

namespace SafeBox.Application.Interfaces
{
    public interface IVaultService
    {
        int GetVaultCount(int userId);
        IEnumerable<Vault> GetVaultsByUserId(int userId);
        int GetFileCount(int vaultId);
        long GetTotalSize(int vaultId);
        void CreateVault(string name, string description, int userId);
    }
}
