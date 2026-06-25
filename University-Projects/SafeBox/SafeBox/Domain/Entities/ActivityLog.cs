using System;

namespace SafeBox.Domain.Entities
{
    
    public class ActivityLog
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; } = "";
        public string Details { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
