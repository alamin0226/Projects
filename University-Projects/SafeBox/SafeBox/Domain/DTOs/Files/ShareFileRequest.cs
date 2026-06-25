using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.DTOs.Files
{
    internal class ShareFileRequest
    {
        public int FileId { get; set; }
        public int SharedByUserId { get; set; }
        public int SharedToUserId { get; set; }
        public int PermissionId { get; set; } // অথবা PermissionType enum থেকে map করতে পারো
    }
}
