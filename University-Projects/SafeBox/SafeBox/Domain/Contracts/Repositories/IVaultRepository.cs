using SafeBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Contracts.Repositories
{
    internal interface IVaultRepository
    {
        int Insert(Vault vault);
        List<Vault> GetByUserId(int userId);
        Vault GetById(int vaultId);

        //Vault CreateVault(string vaultName, string description, int userId);
        //Vault GetVaultById(int vaultId);
        //IEnumerable<Vault> GetVaultsByUserId(int userId);
        //void DeleteVault(int vaultId, int userId);
        //int GetFileCount(int vaultId);
        //long GetTotalSize(int vaultId);
        //int GetVaultCount(int userId);
        //IEnumerable<string> GetVaultNames(int userId);
    }
}
