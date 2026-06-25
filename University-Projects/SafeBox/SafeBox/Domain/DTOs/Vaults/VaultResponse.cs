using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.DTOs.Vaults
{
    internal class VaultResponse
    {
        public int VaultId { get; set; }
        public string VaultName { get; set; } = "";
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
