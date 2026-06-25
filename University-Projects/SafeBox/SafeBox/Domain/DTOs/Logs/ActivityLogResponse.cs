using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.DTOs.Logs
{
    public class ActivityLogResponse
    {
        public int ActivityId { get; set; }
        public string Action { get; set; } = "";
        public string Details { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
