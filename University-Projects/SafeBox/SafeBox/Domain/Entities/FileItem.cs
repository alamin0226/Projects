using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Entities
{
    public class FileItem
    {
        public int FileId { get; set; }
        public string FileName { get; set; } = "";
        public long FileSize { get; set; }
        public string FilePath { get; set; } = "";
        public byte[] EncryptedData { get; set; } // VARBINARY(MAX)
        public DateTime UploadDate { get; set; }
        public int VaultId { get; set; }
    }
}
