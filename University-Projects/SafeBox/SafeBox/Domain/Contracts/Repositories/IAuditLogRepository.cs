using SafeBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Contracts.Repositories
{
    public interface IAuditLogRepository
    {
        int Insert(AuditLog log);
        List<AuditLog> GetLatest(int take);
    }
}
