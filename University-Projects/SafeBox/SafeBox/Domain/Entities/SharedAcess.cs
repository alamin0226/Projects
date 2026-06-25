using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Entities
{
    public class SharedAcess
    {
        public int ShareId { get; set; }
        public int FileId { get; set; }
        public int SharedByUserId { get; set; }
        public int SharedToUserId { get; set; } 
    }
}
