using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.DTOs.Files
{
    internal class UploadFileRequest
    {
        public int VaultId { get; set; }
        public string FileName { get; set; } = "";
        public string FilePath { get; set; } = "";
        public long FileSize { get; set; }

        // যদি encrypted_data ব্যবহার করো
        public byte[] EncryptedData { get; set; }
    }
}
