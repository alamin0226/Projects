using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.DTOs.Vaults
{
    public class CreateVaultRequest
    {
        public int UserId { get; set; }
        public string VaultName { get; set; } = "";
        public string Description { get; set; }
    }
}
