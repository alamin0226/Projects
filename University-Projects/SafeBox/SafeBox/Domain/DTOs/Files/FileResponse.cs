using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.DTOs.Files
{
    public class FileResponse
    {
        public int FileId { get; set; }
        public string FileName { get; set; } = "";
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public int VaultId { get; set; }
    }
}
