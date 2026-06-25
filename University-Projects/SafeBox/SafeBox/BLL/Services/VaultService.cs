using System;
using System.Collections.Generic;
using SafeBox.DAL.Repositories;
using SafeBox.Domain.Entities;

using SafeBox.Application.Interfaces;

namespace SafeBox.Application.Services
{
    public class VaultService : IVaultService
    {
        private readonly IVaultRepository _vaultRepository;

        public VaultService()
        {
            _vaultRepository = new Infrastructure.Repositories.VaultRepository();
        }

        public void CreateVault(string name, string description, int userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Vault name cannot be empty.");

            var vault = new Vault
            {
                UserId = userId,
                VaultName = name,
                Description = description,
                CreatedAt = DateTime.Now
            };

            _vaultRepository.Insert(vault);
        }

        public List<Vault> GetVaultsByUserId(int userId)
        {
            return _vaultRepository.GetByUserId(userId);
        }

        public int GetVaultCount(int userId)
        {
            return _vaultRepository.GetVaultCount(userId);
        }

        public int GetFileCount(int vaultId)
        {
            // This might need a method in repo. For now placeholder or implement.
            return 0; 
        }

        public long GetTotalSize(int vaultId)
        {
            // This might need a method in repo. For now placeholder or implement.
            return 0;
        }

        public void RemoveVault(int vaultId)
        {
            _vaultRepository.DeleteVault(vaultId);
        }
    }
}
