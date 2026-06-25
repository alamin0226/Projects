using System;

namespace SafeBox.Domain.Entities
{
    
    public class Vault
    {
        public int VaultId { get; set; }
        public string VaultName { get; set; } = "";
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
