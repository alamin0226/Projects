using System;

namespace SafeBox.Domain.Entities
{
    /// <summary>
    /// Represents audit log entry for admin/user actions.
    /// Maps to AuditLog table (audit_id IDENTITY(700,17)).
    /// Either UserId or AdminId can be set (one may be null).
    /// </summary>
    public class AuditLog
    {
        public int AuditId { get; set; }
        public int? UserId { get; set; }
        public int? AdminId { get; set; }
        public string Action { get; set; } = "";
        public string Details { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
