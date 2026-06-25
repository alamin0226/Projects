using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Entities
{
    public class FileEntity
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public byte[] EncryptedData { get; set; }
        public int VaultId { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
